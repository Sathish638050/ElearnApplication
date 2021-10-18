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
    public class StaffController : Controller
    {
        private readonly ICourseServ<Course> serv;
        private readonly ITopicServ<Topic> serv1;
        private readonly IClassServ<Class> serv2;
        public StaffController(ICourseServ<Course> _serv,ITopicServ<Topic> _serv1,IClassServ<Class> _serv2)
        {
            serv = _serv;
            serv1 = _serv1;
            serv2 = _serv2;
        }
        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCourse([Bind("CourseName,Description,Picture,UpdateTime,Amount")]Course c)
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            c.UserId = id;
            c.UpdateTime = DateTime.Now;
            if (ModelState.IsValid)
            {
                serv.AddCourse(c);
                return RedirectToAction("Course", "Student");
            }
            else
            {
                return View(c);
            }
        }
        public IActionResult AddTopic(int id)
        {
            ViewBag.CourseId = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTopic([Bind("TopicName,TopicDesc,MaterialPath,VideoPath,CourseId")] Topic t)
        {
            if (ModelState.IsValid)
            {
                serv1.AddTopic(t);
                return RedirectToAction("Course", "Student");
            }
            else
            {
                return View(t);
            }
        }
        public IActionResult AddClass(int id)
        {
            ViewBag.CourseId = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddClass([Bind("CourseId,StartTime,EndTime,Clink,ClassDate")] Class c)
        {
            if (ModelState.IsValid)
            {
                serv2.AddClass(c);
                return RedirectToAction("Course", "Student");
            }
            else
            {
                return View(c);
            }
            
        }
        public async Task<IActionResult> ClassList()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.Role = HttpContext.Session.GetString("Role");
            List<Class> lc = new List<Class>();
            if(ViewBag.Role== "Staff")
            {
                lc = await serv2.GetStaffClass(id);
                if(lc.Count == 0)
                {
                    ViewBag.ErrorMsg = 1;
                }
                else
                {
                    ViewBag.ErrorMsg = 0;
                }
                return View(lc);
            }
            else
            {
                lc = await serv2.GetStudentClass(id);
                if (lc.Count == 0)
                {
                    ViewBag.ErrorMsg = 1;
                }
                else
                {
                    ViewBag.ErrorMsg = 0;
                }
                return View(lc);
            }
            
        }
    }
}
