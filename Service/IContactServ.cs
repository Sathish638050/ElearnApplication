using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public interface IContactServ<Contact>
    {
        public void AddContact(Contact c);
        public Task<List<Contact>> getContact();
    }
}
