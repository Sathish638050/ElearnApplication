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
    public class Contact : IContact<Contact>
    {
        public int CId { get; set; }
        [Required(ErrorMessage ="Name should be must enter")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email should br must enter")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter your Suggestion and Feedback")]
        public string Message { get; set; }

        public async void AddContact(Contact c)
        {
            using(var httpClient  = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using(var response = await httpClient.PostAsync("https://localhost:44370/api/Contact/Contact", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<List<Contact>> getContact()
        {
            List<Contact> lc = new List<Contact>();
            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.GetAsync("https://localhost:44370/api/Contact/GetContactDetails"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<Contact>>(apiResponse);
                }
            }
            return lc;
        }
    }
}
