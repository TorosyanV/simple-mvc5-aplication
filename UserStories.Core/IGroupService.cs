using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Core.Models;

namespace UserStories.Core
{
   public interface IGroupService
    {
        IEnumerable<GroupViewModel> GetAll();
        bool Add(GroupCreateModel model, string createdBy);
        IEnumerable<StoryDetailModel> GetStoriesByGroupId(int id);
        GroupViewModel GetById(int groupId, string userId);

        bool JoinGroup(string userId, int groupId);
        bool LeaveGroup(string userId, int groupId);
        IEnumerable<GroupSelectModel> GetByUserId(string userId);
        IEnumerable<MemberViewModel> GetMemborsByGroupId(int groupId);



    }
}
