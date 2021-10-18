using ELearnApplication.Models;
using ELearnApplication.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserServ<UserAccount> serv;
        private readonly INewStaffServ<NewStaff> serv1;
        private readonly IContactServ<Contact> serv2;
        public AdminController(IUserServ<UserAccount> _serv,INewStaffServ<NewStaff> _serv1,IContactServ<Contact> _serv2)
        {
            serv = _serv;
            serv1 = _serv1;
            serv2 = _serv2;
        }
        public async Task<IActionResult> List(int id)
        {
            List<UserAccount> lu = new List<UserAccount>();
            if(id == 1)
            {
                ViewBag.Title = "StaffList";
                lu = await serv.GetStaffList();
            }
            else
            {
                
                lu = await serv.GetStudentList();
            }
            return View(lu);
        }
        public async Task<IActionResult> NewStaffList()
        {
            List<NewStaff> ln = new List<NewStaff>();
            ln = await serv1.GetNewReq();
            return View(ln);
        }
        public async Task<IActionResult> AcceptReq(NewStaff n)
        {
            int id = n.Sid;
            UserAccount u = new UserAccount();
            u.Username = n.Username;
            u.Email = n.Email;
            u.Password = n.Password;
            u.FirstName = n.Username;
            u.LastName = n.Username;
            u.Role = "Staff";
            u.Phone = n.Phone;
            u.UserImage = n.UserImage;
            serv.AddUser(u);
            serv1.EditReq(id,n);
            return RedirectToAction("List", "Admin", 0);
        }
        public async Task<IActionResult> MessageList()
        {
            List<Contact> lc = await serv2.getContact();
            return View(lc);
        }
    }
}
