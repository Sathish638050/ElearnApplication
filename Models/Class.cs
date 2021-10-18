using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public class Class : IClass<Class>
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Clink { get; set; }
        public DateTime ClassDate { get; set; }

        public async void AddClass(Class c)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44303/api/Staff/ScheduleClass", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<List<Class>> GetStaffClass(int id)
        {
            List<Class> lc = new List<Class>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44303/api/Staff/getClassStaff?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<Class>>(apiResponse);
                }
            }
            return lc;
        }

        public async Task<List<Class>> GetStudentClass(int id)
        {
            List<Class> lc = new List<Class>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44359/api/Student/GetStudentClass?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<Class>>(apiResponse);
                }
            }
            return lc;
        }
    }
}
