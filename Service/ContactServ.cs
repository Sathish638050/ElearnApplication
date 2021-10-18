using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class ContactServ : IContactServ<Contact>
    {
        private readonly IContactRepo<Contact> repo;
        public ContactServ(IContactRepo<Contact> _repo)
        {
            repo = _repo;
        }
        public void AddContact(Contact c)
        {
             repo.AddContact(c);
        }

        public Task<List<Contact>> getContact()
        {
            return repo.getContact();
        }
    }
}
