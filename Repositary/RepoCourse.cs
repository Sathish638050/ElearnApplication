using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class RepoCourse : IRepoCourse<Course>
    {
        private readonly ICourse<Course> obj;
        public RepoCourse(ICourse<Course> _obj)
        {
            obj = _obj;
        }

        public void AddCourse(Course c)
        {
            obj.AddCourse(c);
        }

        public void EditCourse(int id, Course c)
        {
            obj.EditCourse(id, c);
        }

        public Task<List<Course>> GetAllCourse()
        {
            return obj.GetAllCourse();
        }

        public Task<List<Course>> getCourseByUser(int id)
        {
            return obj.getCourseByUser(id);
        }

        public Task<Course> GetDetailById(int id)
        {
            return obj.GetDetailById(id);
        }

        public Task<List<Course>> GetEnrollCourses(int id)
        {
            return obj.GetEnrollCourses(id);
        }
    }
}
