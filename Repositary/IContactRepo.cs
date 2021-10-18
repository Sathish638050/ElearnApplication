using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
     public  interface IContactRepo<Contact>
    {
        public void AddContact(Contact c);
        public Task<List<Contact>> getContact();
    }
}
