using ELearnApplication.Models;
using ELearnApplication.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly INewStaffServ<NewStaff> serv1;
        private readonly IContactServ<Contact> serv2;
        private readonly IClassServ<Class> serv3;
        private readonly ICourseServ<Course> courseserv;
        private readonly IUserServ<UserAccount> userserv;
        public HomeController(INewStaffServ<NewStaff> _serv1,IContactServ<Contact> _serv2,IClassServ<Class> _serv3,ICourseServ<Course> _courseserv,IUserServ<UserAccount> _userserv)
        {
            
            serv1 = _serv1;
            serv2 = _serv2;
            serv3 = _serv3;
            courseserv = _courseserv;
            userserv = _userserv;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewModel vc = new ViewModel();
            ViewBag.Role = HttpContext.Session.GetString("Role");
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            if (id != 0)
            {
                if (ViewBag.Role == "Student")
                {
                    vc.Class = await serv3.GetStudentClass(id);
                    vc.Course =  await courseserv.GetEnrollCourses(id);
                    
                }
                else if (ViewBag.Role == "Staff")
                {
                    vc.Class = await serv3.GetStaffClass(id);
                    vc.Course = await courseserv.getCourseByUser(id);
                }
                else if(ViewBag.Role == "Admin")
                {
                    vc.Course = await courseserv.GetAllCourse();
                    ViewBag.ErrorMsg = "Empty";
                    return View(vc);
                }
                if ((vc.Class.Count != 0)||(vc.Course.Count !=0))
                {
                    return View(vc);
                }
                else
                {

                    ViewBag.ErrorMsg = "Empty";
                    vc.Course = await courseserv.GetAllCourse();
                    return View(vc);
                }
            }
            else
            {
                ViewBag.ErrorMsg = "Empty";
                vc.Course = await courseserv.GetAllCourse();
                return View(vc);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStaff([Bind("Name,Username,Password,Phone,High,Department,College,Experience,Status,UserImage,Email")] NewStaff n)
        {
            if (ModelState.IsValid)
            {
                UserAccount us = new UserAccount();
                List<NewStaff> ne = new List<NewStaff>();
                us = await userserv.GetDetailByUsername(n.Username);
                if(us == null)
                {
                    ne = await serv1.getDetailByName(n.Username);
                    if(ne.Count == 0)
                    {
                        serv1.AddStaff(n);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Username already exist";
                        return View();
                    }
                }
                else

                {
                    ViewBag.ErrorMsg = "Username already exist";
                    return View();
                }
                
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact([Bind("Name,Email,Message")]Contact c)
        {
            if (ModelState.IsValid)
            {
                serv2.AddContact(c);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(c);
            }
            
        }
    }    
}
