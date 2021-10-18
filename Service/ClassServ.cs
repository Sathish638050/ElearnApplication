using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class ClassServ : IClassServ<Class>
    {
        private readonly IClassRepo<Class> repo;
        public ClassServ(IClassRepo<Class> _repo)
        {
            repo = _repo;
        }
        public void AddClass(Class c)
        {
            repo.AddClass(c);
        }

        public Task<List<Class>> GetStaffClass(int id)
        {
            return repo.GetStaffClass(id);
        }

        public Task<List<Class>> GetStudentClass(int id)
        {
            return repo.GetStudentClass(id);
        }
    }
}
