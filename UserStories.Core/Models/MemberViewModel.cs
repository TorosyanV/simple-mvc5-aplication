using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStories.Core.Models
{
   public class MemberViewModel
    {
        public string Name { get; set; }
        public int GroupCount { get; set; }
        public int StoryCount { get; set; }
    }
}
