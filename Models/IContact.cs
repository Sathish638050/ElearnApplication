using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public interface IContact<Contact>
    {
        public void AddContact(Contact c);
        public Task<List<Contact>> getContact();
    }
}
