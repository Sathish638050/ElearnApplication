using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class RepoNewStaff : IRepoNewStaff<NewStaff>
    {
        private readonly INewStaff<NewStaff> obj;
        public RepoNewStaff(INewStaff<NewStaff> _obj)
        {
            obj = _obj;
        }
        public void AddStaff(NewStaff n)
        {
            obj.AddStaff(n);
        }

        public void EditReq(int id, NewStaff n)
        {
            obj.EditReq(id,n);
        }

        public Task<List<NewStaff>> getDetailByName(string name)
        {
            return obj.getDetailByName(name);
        }

        public Task<List<NewStaff>> GetNewReq()
        {
            return obj.GetNewReq();
        }
    }
}
