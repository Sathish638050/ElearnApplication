using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class ClassRepo : IClassRepo<Class>
    {
        private readonly IClass<Class> obj;
        public ClassRepo(IClass<Class> _obj)
        {
            obj = _obj;
        }
        public void AddClass(Class c)
        {
            obj.AddClass(c);
        }

        public Task<List<Class>> GetStaffClass(int id)
        {
            return obj.GetStaffClass(id);
        }

        public Task<List<Class>> GetStudentClass(int id)
        {
            return obj.GetStudentClass(id);
        }
    }
}
