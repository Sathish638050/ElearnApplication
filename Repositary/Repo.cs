using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class Repo : IRepo<UserAccount>
    {
        private readonly IUserAccount<UserAccount> obj;
        
        public  Repo(IUserAccount<UserAccount> _obj)
        {
            obj = _obj;
        }
        public void AddUser(UserAccount u)
        {
            obj.AddUser(u);
        }

        public Task<bool> CheckAuthentication()
        {
            return obj.CheckAuthentication();
        }

        public void EditProfileImage(int id, UserAccount u)
        {
            obj.EditProfileImage(id, u);
        }

        public Task<UserAccount> GetDetail(UserAccount u)
        {
            return obj.GetDetail(u);
        }

        public Task<UserAccount> GetDetailById(int id)
        {
            return obj.GetDetailById(id);
        }

        public Task<UserAccount> GetDetailByUsername(string name)
        {
            return obj.GetDetailByUsername(name);
        }

        public Task<List<UserAccount>> GetStaffList()
        {
            return obj.GetStaffList();
        }

        public Task<List<UserAccount>> GetStudentList()
        {
            return obj.GetStudentList();
        }

        public Task<string> Login(UserAccount u)
        {
            return obj.Login(u);
        }

        public void UpdateUser(int id, UserAccount u)
        {
            obj.UpdateUser(id, u);
        }
    }
}
