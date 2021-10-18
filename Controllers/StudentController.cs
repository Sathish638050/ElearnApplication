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
    
    public class StudentController : Controller
    {
        private readonly ICourseServ<Course> serv;
        private readonly ICustomerServ<Customer> serv1;
        private readonly ICourseEnroll<CourseEnroll> serv2;
        private readonly ITopicServ<Topic> serv3;
        private readonly IUserServ<UserAccount> serv4;
        public StudentController(ICourseServ<Course> _serv,ICustomerServ<Customer> _serv1,ICourseEnroll<CourseEnroll> _serv2,ITopicServ<Topic> _serv3,IUserServ<UserAccount> _serv4)
        {
            serv = _serv;
            serv1 = _serv1;
            serv2 = _serv2;
            serv3 = _serv3;
            serv4 = _serv4; 
        }
        public async Task<IActionResult> Course(int id)
        {
            ViewBag.Role = HttpContext.Session.GetString("Role");
            if(id == 0)
            {
                ViewBag.Page = "Course";
                List<Course> lc = await serv.GetAllCourse();
                return View(lc);
            }
            else
            {
                if(ViewBag.Role == "Staff")
                {
                    ViewBag.Page = "MyCourse";
                    List<Course> lc = await serv.getCourseByUser(id);
                    return View(lc);
                }
                else
                {
                    ViewBag.Page = "MyCourse";
                    List<Course> lc = await serv.GetEnrollCourses(id);
                    return View(lc);
                }
            }
        }
        public async Task<IActionResult> DisplayDetail(int id)
        {
            int uid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            ViewBag.Role = HttpContext.Session.GetString("Role");
            List<Course> lc = await serv.GetEnrollCourses(uid);
            if (uid != 0)
            {
               if(ViewBag.Role == "Student")
                {
                    if(lc.Any(a => a.CourseId == id))
                    {
                        ViewBag.ErrorMessage = "This Course Already Enrolled";
                    }
                }
                Course c = await serv.GetDetailById(id);
                ViewBag.Course = c;
                return View(c);
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        public async Task<IActionResult> Payment(int id)
        {
            ViewBag.UserId = HttpContext.Session.GetString("UserId");
            
            if (ViewBag.UserId != null)
            {
                
                ViewBag.CourseId = id;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment([Bind("Name,Debit,Cvv,Expiry,UserId,CourseId")]Customer c)
        {
            if(c.Cvv == 0)
            {
                ViewBag.cvvError = "Enter CVV Number";
            } 
            if (ModelState.IsValid)
            {
                serv1.MakePayment(c);
                CourseEnroll cd = new CourseEnroll()
                {
                    UserId = (int)c.UserId,
                    CourseId = (int)c.CourseId
                };
                serv2.Enroll(cd);
                return RedirectToAction("Course", "Student");
            }
            else
            {
                return View(c);
            }
            
        }
        
        public async Task<IActionResult> WorkPlace(int id)
        {
            List<Topic> lt = new List<Topic>();
            lt = await serv3.GetCourseTopic(id);
            if(lt.Count == 0)
            {
                ViewBag.TopicCount = "Empty";
                ViewBag.CourseId = id;
            }
            return View(lt);
        }
        public async Task<IActionResult> Profile()
        {
           int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            UserAccount u = new UserAccount();
            u = await serv4.GetDetailById(id);
            ViewBag.Users = u;
            return View(u);
        }
        public async Task<IActionResult> EditUser()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            UserAccount u = new UserAccount();
            u = await serv4.GetDetailById(id);
            return View(u);
        }
        [HttpPost]
        public async Task<IActionResult> EditUser( UserAccount u)
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            serv4.UpdateUser(id, u);
            return RedirectToAction("Profile", "Student");
        }
        public async Task<IActionResult> EditCourse(int id)
        {
            Course c = await serv.GetDetailById(id);
            ViewBag.Course = c;
            return View(c);
        }
        [HttpPost]
        public async Task<IActionResult> EditCourse(Course c)
        {
            c.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            c.UpdateTime = DateTime.Now;
            int id = c.CourseId;
            serv.EditCourse(id, c);
            return RedirectToAction("Course", "Student");
        }
        [HttpPost]
        public async Task<IActionResult> EditImage(UserAccount u)
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            serv4.EditProfileImage(id,u);
            return RedirectToAction("Profile","Student");
        }
    }


}
