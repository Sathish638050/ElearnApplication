using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public interface ICourseEnrollServ<CourseEnroll>
    {
        public void Enroll(CourseEnroll c);
    }
}
