using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public interface IRepoNewStaff<NewStaff>
    {
        public void AddStaff(NewStaff n);
        public Task<List<NewStaff>> GetNewReq();
        public void EditReq(int id,NewStaff n);
        public Task<List<NewStaff>> getDetailByName(string name);
    }
}
