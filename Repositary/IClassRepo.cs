using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public interface IClassRepo<Class>
    {
        public void AddClass(Class c);
        public Task<List<Class>> GetStaffClass(int id);
        public Task<List<Class>> GetStudentClass(int id);
    }
}
