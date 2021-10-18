using ELearnApplication.Models;
using ELearnApplication.Repositary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearnApplication.Service
{
    public class TopicServ : ITopicServ<Topic>
    {
        private readonly ITopicRepo<Topic> repo;
        public TopicServ(ITopicRepo<Topic> _repo)
        {
            repo = _repo;
        }

        public void AddTopic(Topic t)
        {
            repo.AddTopic(t);
        }

        public Task<List<Topic>> GetCourseTopic(int id)
        {
            return repo.GetCourseTopic(id);
        }
    }
}
