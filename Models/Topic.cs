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
    public class Topic : ITopic<Topic>
    {
        public int TopicId { get; set; }
        [Required(ErrorMessage ="Topic Name Should Be Required")]
        public string TopicName { get; set; }
        [Required(ErrorMessage ="Description is Required")]
        public string TopicDesc { get; set; }
        [Required(ErrorMessage = "Material is Required")]
        public string MaterialPath { get; set; }
        [Required(ErrorMessage = "Videp is Required")]
        public string VideoPath { get; set; }
        public int CourseId { get; set; }

        public async void AddTopicAsync(Topic t)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44303/api/Staff/AddTopic", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }

        public async Task<List<Topic>> GetCourseTopic(int id)
        {
            List<Topic> lc = new List<Topic>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44303/api/Staff/Topics?cid=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    lc = JsonConvert.DeserializeObject<List<Topic>>(apiResponse);
                }
            }
            return lc;
        }
    }
}
