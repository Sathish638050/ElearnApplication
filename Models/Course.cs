using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public class Course : ICourse<Course>
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage ="Course Name is Required")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Course Description is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Course Picture is Required")]
        public string Picture { get; set; }
        public DateTime UpdateTime { get; set; }
        [Required(ErrorMessage = " Amount is Required")]
        public decimal Amount { get; set; }

        public int UserId { get; set; }

        public async void AddCourse(Course c)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://staffcontrollapi.azurewebsites.net//api/Staff/AddCourses", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async void EditCourse(int id, Course c)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://staffcontrollapi.azurewebsites.net//api/Staff/EditCourse?id=" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<List<Course>> GetAllCourse()
        {
            List<Course> lc = new List<Course>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://studentapi1.azurewebsites.net/api/Student/GetAllCourse"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }
        
            return lc;
        }

        public async Task<List<Course>> getCourseByUser(int id)
        {
            List<Course> lc = new List<Course>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://staffcontrollapi.azurewebsites.net/api/Staff/GetCourseByUser?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }
            return lc;
        }

        public async Task<Course> GetDetailById(int id)
        {
            Course c = new Course();
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://studentapi1.azurewebsites.net/api/Student/GetCourseById?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Course>(apiResponse);                
                }
            }
            return c;
        }

        public async Task<List<Course>> GetEnrollCourses(int id)
        {
            List<Course> lc = new List<Course>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://studentapi1.azurewebsites.net/api/Student/GetEnrollCourses?myid=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }
            return lc;
        }
    }
}
