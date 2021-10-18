
using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public interface ICustomerServ<Customer>
    {
        public void MakePayment(Customer c);
    }
}
