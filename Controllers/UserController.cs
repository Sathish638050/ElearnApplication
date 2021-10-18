using ELearnApplication.Models;
using ELearnApplication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServ<UserAccount> serv;
        private readonly INewStaffServ<NewStaff> serv1;
        public UserController(IUserServ<UserAccount> _serv,INewStaffServ<NewStaff> _serv1)
        {
            serv = _serv;
            serv1 = _serv1;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind("Username,Email,Password,FirstName,LastName,Role,Phone,UserImage")]UserAccount u)
        {
            if (ModelState.IsValid)
            {
                UserAccount us = new UserAccount();
                List<NewStaff> ne = new List<NewStaff>();
                
                us = await serv.GetDetailByUsername(u.Username);
                if(us == null)
                {
                    ne = await serv1.getDetailByName(u.Username);
                    if(ne.Count==0)
                    {
                        serv.AddUser(u);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetString("ErrorUser", "Username already exist");
                        return View(u);
                    }
                }
                else
                {
                    HttpContext.Session.SetString("ErrorUser", "Username already exist");
                    return View(u);
                }
            }
            else
            {
                return View(u);
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserAccount u)
        {
            if((u.Username == null))
            {
                if (u.Password == null)
                {
                    ViewBag.UserNameError = "Enter Username";
                    ViewBag.PassError = "Enter Password";
                    return View();
                }
                else
                {
                    ViewBag.UserNameError = "Enter Username";
                    return View();
                }
            }
            else
            {
                if (u.Password == null)
                {
                    ViewBag.PassError = "Enter Password";
                    return View();
                }
                else
                {
                    UserAccount ua = new UserAccount();
                    List<NewStaff> ne = new List<NewStaff>();
                    string s = await serv.Login(u);
                    if (s == "Invalid")
                    {
                        ne = await serv1.getDetailByName(u.Username);
                        if (ne.Count != 0)
                        {
                            ViewBag.Message = "You Staff Request Has Been Pending";
                            return View();
                        }
                        else
                        {
                            ViewBag.Message = "Username and Password are invalid";
                            return View();
                        }

                    }
                    else
                    {
                        ua = await serv.GetDetail(u);
                        HttpContext.Session.SetString("UserId", ua.UserId.ToString());
                        HttpContext.Session.SetString("Role", ua.Role);
                        HttpContext.Session.SetString("UserImage", ua.UserImage);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
