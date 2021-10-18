using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class CustomerServ : ICustomerServ<Customer>
    {
        private readonly IRepoCustomer<Customer> repo;
        public CustomerServ(IRepoCustomer<Customer> _repo)
        {
            repo = _repo;
        }
        public void MakePayment(Customer c)
        {
            repo.MakePayment(c);
        }
    }
}
