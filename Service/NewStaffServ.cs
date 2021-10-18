using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class NewStaffServ : INewStaffServ<NewStaff>
    {
        private readonly IRepoNewStaff<NewStaff> repo;
        public NewStaffServ(IRepoNewStaff<NewStaff> _repo)
        {
            repo = _repo;
        }
        public void AddStaff(NewStaff n)
        {
            repo.AddStaff(n);
        }

        public void EditReq(int id, NewStaff n)
        {
            repo.EditReq(id,n);
        }

        public Task<List<NewStaff>> getDetailByName(string name)
        {
            return repo.getDetailByName(name);
        }

        public Task<List<NewStaff>> GetNewReq()
        {
            return repo.GetNewReq();
        }
    }
}
