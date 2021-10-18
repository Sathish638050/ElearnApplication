using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public interface ITopicServ<Topic>
    {
        public void AddTopic(Topic t);
        public Task<List<Topic>> GetCourseTopic(int id);
    }
}
