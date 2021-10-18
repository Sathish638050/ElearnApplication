using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public interface IRepoCustomer<Customer>
    {
        public void MakePayment(Customer c);
    }
}
