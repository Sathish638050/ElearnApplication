using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class CourseEnrollServ : ICourseEnrollServ<CourseEnroll>
    {
        private readonly IRepoCourseEnroll<CourseEnroll> repo;
        public CourseEnrollServ(IRepoCourseEnroll<CourseEnroll> _repo)
        {
            repo = _repo;
        }

        public void Enroll(CourseEnroll c)
        {
            repo.Enroll(c);
        }
    }
}
