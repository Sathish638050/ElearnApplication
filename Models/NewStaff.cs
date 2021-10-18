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
    public class NewStaff:INewStaff<NewStaff>
    {
        public int Sid { get; set; }
        [Required(ErrorMessage ="Name Should be Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Username Should be Required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password Should be Required")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Password Must 6 Characters")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Phone Number Should be Required")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Phone Number must be 10 numbers")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="UserImage File Should be must")]
        public string UserImage { get; set; }
        [Required(ErrorMessage ="Your Higher education level should be must")]
        public string High { get; set; }
        [Required(ErrorMessage ="Your department of education is required")]
        public string Department { get; set; }
        [Required(ErrorMessage ="Your College name is required")]
        public string College { get; set; }
        [Required(ErrorMessage ="Your Experience level is must")]
        public string Experience { get; set; }
        [Required(ErrorMessage ="Email Should be must")]
        public string Email { get; set; }

        

        public async void AddStaff(NewStaff n)
        {
            NewStaff s = new NewStaff();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(n), Encoding.UTF8, "application/json");
                using(var response = await httpClient.PostAsync("https://localhost:44370/api/AddNewStaff/AddRequestStaff", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    s = JsonConvert.DeserializeObject<NewStaff>(apiResponse);
                }
            }
        }

        public async void EditReq(int id,NewStaff n)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(n), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44370/api/Auth/EditRequest?id=" + id,content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<List<NewStaff>> getDetailByName(string name)
        {
            List<NewStaff> lc = new List<NewStaff>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44370/api/Auth/GetDetailByReqName?name="+name))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<NewStaff>>(apiResponse);
                }
            }
            return lc;
        }

        public async Task<List<NewStaff>> GetNewReq()
        {
            List<NewStaff> lc = new List<NewStaff>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44370/api/Auth/GetNewRequest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<NewStaff>>(apiResponse);
                }
            }

            return lc;
        }
    }
}
