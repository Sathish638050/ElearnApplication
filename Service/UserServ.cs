using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class UserServ : IUserServ<UserAccount>
    {
        private readonly IRepo<UserAccount> repo;
        public UserServ(IRepo<UserAccount> _repo)
        {
            repo = _repo;
        }
        public void AddUser(UserAccount u)
        {
            repo.AddUser(u);
        }

        public Task<bool> CheckAuthentication()
        {
            return repo.CheckAuthentication();
        }

        public void EditProfileImage(int id, UserAccount u)
        {
            repo.EditProfileImage(id, u);
        }

        public Task<UserAccount> GetDetail(UserAccount u)
        {
            return repo.GetDetail(u); 
        }

        public Task<UserAccount> GetDetailById(int id)
        {
            return repo.GetDetailById(id);
        }

        public Task<UserAccount> GetDetailByUsername(string name)
        {
            return repo.GetDetailByUsername(name);
        }

        public Task<List<UserAccount>> GetStaffList()
        {
            return repo.GetStaffList();
        }

        public Task<List<UserAccount>> GetStudentList()
        {
            return repo.GetStudentList();
        }

        public Task<string> Login(UserAccount u)
        {
            return repo.Login(u);
        }

        public void UpdateUser(int id, UserAccount u)
        {
            repo.UpdateUser(id, u);
        }
    }
}
