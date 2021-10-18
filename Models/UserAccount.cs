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
    public class UserAccount : IUserAccount<UserAccount>
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Password must be 6 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Last Name is required")]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required(ErrorMessage ="Phone Number is reqired")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="Phone Number must be 10 numbers")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage ="Profile image is required")]
        public string UserImage { get; set; }

        public async void AddUser(UserAccount u)
        {
            UserAccount EmlObj = new UserAccount();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44370/api/Auth/Register", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    EmlObj = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
        }
        public async Task<bool> CheckAuthentication()
        {
            bool auth = false;
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:44370/api/Auth/CheckAuthentication"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    auth = Convert.ToBoolean(apiResponse);
                }
            }
            return auth;
        }

        public async void EditProfileImage(int id, UserAccount u)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44359/api/Student/UpdateUserPic?id=" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<UserAccount> GetDetail(UserAccount u)
        {
            UserAccount ua = new UserAccount();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var response = await  httpClient.PostAsync("https://localhost:44370/api/Auth/UserDetail", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ua = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
            return ua;
        }

        public async Task<UserAccount> GetDetailById(int id)
        {
            UserAccount ua = new UserAccount();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44359/api/Student/GetStudentByID?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ua = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
            return ua;
        }

        public async Task<UserAccount> GetDetailByUsername(string name)
        {
            UserAccount ua = new UserAccount();
            using(var httpClient = new HttpClient())
            {
                using(var response = await httpClient.GetAsync("https://localhost:44370/api/Auth/" + name))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ua = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
            return ua;
        }

        public async Task<List<UserAccount>> GetStaffList()
        {
            List<UserAccount> lc = new List<UserAccount>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44370/api/Auth/GetStaffList"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<UserAccount>>(apiResponse);
                }
            }

            return lc;
        }

        public async Task<List<UserAccount>> GetStudentList()
        {
            List<UserAccount> lc = new List<UserAccount>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44370/api/Auth/GetStudentList"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<UserAccount>>(apiResponse);
                }
            }

            return lc;
        }

        public async Task<string> Login(UserAccount u)
        {
            string token = "";
            UserAccount lu = new UserAccount();
            using(var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using(var response = await httpClient.PostAsync("https://localhost:44370/api/Auth", content))
                {
                    token = await response.Content.ReadAsStringAsync();
                }
            }
            return token;
        }

        public async void UpdateUser(int id, UserAccount u)
        {
            
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(u), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44359/api/Student/UpdateUser?id="+id,content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
