using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class CourseServ : ICourseServ<Course>
    {
        private readonly IRepoCourse<Course> repo;
        public CourseServ(IRepoCourse<Course> _repo)
        {
            repo = _repo;
        }

        public void AddCourse(Course c)
        {
            repo.AddCourse(c);
        }

        public void EditCourse(int id, Course c)
        {
            repo.EditCourse(id, c);
        }

        public Task<List<Course>> GetAllCourse()
        {
            return repo.GetAllCourse();
        }

        public Task<List<Course>> getCourseByUser(int id)
        {
            return repo.getCourseByUser(id);
        }

        public Task<Course> GetDetailById(int id)
        {
            return repo.GetDetailById(id);
        }

        public Task<List<Course>> GetEnrollCourses(int id)
        {
            return repo.GetEnrollCourses(id);
        }
    }
}
