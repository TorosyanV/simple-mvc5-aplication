using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Core.Models;

namespace UserStories.Core
{
  public  interface IStoryService
    {
       IEnumerable<StoryViewModel> GetByUserId(string userId);
       StoryDetailModel GetById(int id);
       bool Add(string createdByUserId, StoryCreateModel newstory, List<int> groupIds);
       bool Edit(StoryEditModel story);



    }
}
