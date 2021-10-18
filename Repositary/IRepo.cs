using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public interface IRepo<UserAccount>
    {
        public void AddUser(UserAccount u);

        public Task<string> Login(UserAccount u);
        public Task<UserAccount> GetDetail(UserAccount u);
        public Task<UserAccount> GetDetailByUsername(string name);
        public Task<bool> CheckAuthentication();
        public Task<UserAccount> GetDetailById(int id);
        public void UpdateUser(int id, UserAccount u);
        public Task<List<UserAccount>> GetStudentList(); 
        public Task<List<UserAccount>> GetStaffList();
        public void EditProfileImage(int id, UserAccount u);
    }
}
