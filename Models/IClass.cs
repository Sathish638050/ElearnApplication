using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public interface IClass<Class>
    {
        public void AddClass(Class c);
        public Task<List<Class>> GetStaffClass(int id);
        public Task<List<Class>> GetStudentClass(int id);
    }
}
