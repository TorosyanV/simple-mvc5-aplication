using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Models;

namespace UserStories.Core.Models
{
  public  class StoryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
     
        public DateTime PostedOn { get; set; }
    }


  public class StoryCreateModel
  {

      public string Title { get; set; }
      public string Description { get; set; }

      public string Content { get; set; }

      public List<GroupSelectModel> Groups { get; set; }
  }
  public class StoryDetailModel
  {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }

      public string Content { get; set; }
      public DateTime PostedOn { get; set; }

      public string UserId { get; set; }
  }
  public class StoryEditModel
  {
      public int Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }

      public string Content { get; set; }

  }

    
    
}
