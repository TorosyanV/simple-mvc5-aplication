using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Models;

namespace UserStories.DAL
{
    public class Group
    {
        public Group()
        {
            Stories = new HashSet<Story>();
            JoinedUsers = new HashSet<ApplicationUser>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Story> Stories { get; set; }
        public virtual ICollection<ApplicationUser> JoinedUsers { get; set; }


    }
}
