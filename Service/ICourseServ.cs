using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public interface ICourseServ<Course>
    {
        public Task<List<Course>> GetAllCourse();
        public Task<Course> GetDetailById(int id);
        public Task<List<Course>> GetEnrollCourses(int id);
        public void AddCourse(Course c);
        public Task<List<Course>> getCourseByUser(int id);
        public void EditCourse(int id, Course c);
    }
}
