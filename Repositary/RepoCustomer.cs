using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class RepoCustomer : IRepoCustomer<Customer>
    {
        private ICustomer<Customer> obj;
        public RepoCustomer(ICustomer<Customer> _obj)
        {
            obj = _obj;
        }
        public void MakePayment(Customer c)
        {
            obj.MakePaymentAsync(c);
        }
    }
}
