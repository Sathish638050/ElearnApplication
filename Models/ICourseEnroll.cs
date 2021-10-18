using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public interface ICourseEnroll<CourseEnroll>
    {
        public void Enroll(CourseEnroll c);
    }
}
