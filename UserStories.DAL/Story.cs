using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using UserStories.Models;

namespace UserStories.DAL
{
    public class Story
    {
        public Story()
        {
            Groups = new HashSet<Group>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Group> Groups { get; set; }

    }
}