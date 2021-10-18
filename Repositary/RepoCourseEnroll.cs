using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class RepoCourseEnroll : IRepoCourseEnroll<CourseEnroll>
    {
        private ICourseEnroll<CourseEnroll> obj;
        public RepoCourseEnroll(ICourseEnroll<CourseEnroll> _obj)
        {
            obj = _obj;
        }
        public void Enroll(CourseEnroll c)
        {
            obj.Enroll(c);
        }
    }
}
