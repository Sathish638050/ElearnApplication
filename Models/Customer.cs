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
    public class Customer : ICustomer<Customer>
    {
        public int CustId { get; set; }
        [Required(ErrorMessage ="Enter you Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter you Depit Card Number")]
        [StringLength(16,MinimumLength =16,ErrorMessage ="Invalid Debit Card Number")]
        public string Debit { get; set; }
        [Required(ErrorMessage ="Enter Card CVV Number")]
        [Range(100,999,ErrorMessage ="Invalid CVV Number")]
        public int Cvv { get; set; }
        [Required(ErrorMessage = "Enter you Expiry Year")]
        public string Expiry { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public async void MakePaymentAsync(Customer c)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:44359/api/Student/MakePayment", content))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
