using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStories.Core.Models
{
  public  class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MemborsCount { get; set; }
        public int StoriesCount { get; set; }
        public bool IsJoined { get; set; }
    }

  public class GroupCreateModel
  {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
    
  }
  public class GroupSelectModel
  {
      public int Id { get; set; }

      public string Name { get; set; }
  }

}
