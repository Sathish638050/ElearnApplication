using ELearnApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Repositary
{
    public class TopicRepo : ITopicRepo<Topic>
    {
        private readonly ITopic<Topic> obj;
        public TopicRepo(ITopic<Topic> _obj)
        {
            obj = _obj;
        }

        public void AddTopic(Topic t)
        {
            obj.AddTopicAsync(t);
        }

        public Task<List<Topic>> GetCourseTopic(int id)
        {
            return obj.GetCourseTopic(id);
        }
    }
}
