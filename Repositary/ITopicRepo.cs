using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public interface ITopicRepo<Topic>
    {
        public void AddTopic(Topic t);
        public Task<List<Topic>> GetCourseTopic(int id);
    }
}
