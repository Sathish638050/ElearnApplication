using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public interface ICustomer<Customer>
    {
        public void MakePaymentAsync(Customer c);
    }
}
