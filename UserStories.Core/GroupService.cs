using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Core.Models;
using UserStories.DAL;
using Microsoft.AspNet.Identity;
using UserStories.Models;
namespace UserStories.Core
{
    public class GroupService : IGroupService
    {
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;
        public GroupService(IGenericRepository<Group> groupRepository, IGenericRepository<ApplicationUser> userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<GroupViewModel> GetAll()
        {
            return _groupRepository.Get.Select(g => new GroupViewModel()
              {
                  Id = g.Id,
                  Name = g.Name,
                  Description = g.Description,
                  MemborsCount = g.JoinedUsers.Count,
                  StoriesCount = g.Stories.Count

              });
        }

        public bool Add(GroupCreateModel model, string createdBy)
        {


            var group = new Group();
            group.Name = model.Name;
            group.Description = model.Description;
            group.UserId = createdBy;
            try
            {
                _groupRepository.Add(group);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public IEnumerable<StoryDetailModel> GetStoriesByGroupId(int id)
        {
            var stories = _groupRepository.Get.FirstOrDefault(g => g.Id == id).Stories.Select(s => new StoryDetailModel() { Id = s.Id, Content = s.Content, Description = s.Description, Title = s.Title, PostedOn = s.PostedOn, UserId = s.UserId }).ToList();
            return stories;
        }



        public GroupViewModel GetById(int groupId, string userId)
        {
            return _groupRepository.Get.Select(g => new GroupViewModel()
            {
                Id = g.Id,
                Name = g.Name,
                MemborsCount = g.JoinedUsers.Count,
                Description = g.Description,
                IsJoined = g.JoinedUsers.Where(u => u.Id == userId).Count() == 0 ? false : true
            }).FirstOrDefault(g => g.Id == groupId);
        }


        public bool JoinGroup(string userId, int groupId)
        {
            var user = _userRepository.Get.FirstOrDefault(u => u.Id == userId);
            var group = _groupRepository.Get.FirstOrDefault(g => g.Id == groupId);
            group.JoinedUsers.Add(user);
            _groupRepository.AddOrUpdate(group);
            return true;

        }


        public IEnumerable<GroupSelectModel> GetByUserId(string userId)
        {
            var groups = _userRepository.Get.First(u => u.Id == userId).JoinedGroups.Select(g => new GroupSelectModel() { Id = g.Id, Name = g.Name }).ToList();
            return groups;
        }


        public bool LeaveGroup(string userId, int groupId)
        {
            var user = _userRepository.Get.FirstOrDefault(u => u.Id == userId);
            var group = _groupRepository.Get.FirstOrDefault(g => g.Id == groupId);
            group.JoinedUsers.Remove(user);
            _groupRepository.Update(group);
            return true;
        }


        public IEnumerable<MemberViewModel> GetMemborsByGroupId(int groupId)
        {
          return  _groupRepository.Get.FirstOrDefault(g => g.Id == groupId).JoinedUsers.Select(s=>new MemberViewModel() { 
             Name=s.UserName,
              GroupCount=s.JoinedGroups.Count,
               StoryCount=s.Stories.Count
            }).ToList();
        }
    }
}
