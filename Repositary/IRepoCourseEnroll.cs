﻿using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public interface IRepoCourseEnroll<CourseEnroll>
    {
        public void Enroll(CourseEnroll c); 
    }
}
