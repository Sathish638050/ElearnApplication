using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public class CourseEnroll : ICourseEnroll<CourseEnroll>
    {
        public int EnrollId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public async void Enroll(CourseEnroll c)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://studentapi1.azurewebsites.net/api/Student/CourseEnroll", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //good = JsonConvert.DeserializeObject<Customer>(apiResponse);
                }
            }
        }
    }
}
