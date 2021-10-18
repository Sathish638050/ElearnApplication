using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Models
{
    public interface ITopic<Topic>
    {
        public void AddTopicAsync(Topic t);
        public Task<List<Topic>> GetCourseTopic(int id);
    }
}
