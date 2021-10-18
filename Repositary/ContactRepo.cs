using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class ContactRepo : IContactRepo<Contact>
    {
        private readonly IContact<Contact> obj;
        public ContactRepo(IContact<Contact> _obj)
        {
            obj = _obj;
        }
        public void AddContact(Contact c)
        {
            obj.AddContact(c);
        }

        public Task<List<Contact>> getContact()
        {
            return obj.getContact();
        }
    }
}
