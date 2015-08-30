using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Core.Models;
using UserStories.DAL;
using UserStories.Models;

namespace UserStories.Core
{
    public class StoryService : IStoryService
    {

        private readonly IGenericRepository<Story> _storyRepository;
        private readonly IGenericRepository<Group> _groupRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;
        public StoryService(IGenericRepository<Story> storyRepository, IGenericRepository<Group> groupRepository, IGenericRepository<ApplicationUser> userRepository)
        {
            _storyRepository = storyRepository;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<StoryViewModel> GetByUserId(string userId)
        {
            return _storyRepository.Get.Where(s => s.UserId == userId).Select(s => new StoryViewModel()
            {
                Id = s.Id,
                PostedOn = s.PostedOn,
                Title = s.Title
            });
        }

        public StoryDetailModel GetById(int id)
        {
            var story= _storyRepository.Get.Where(s => s.Id == id).Select(s => new StoryDetailModel()
            {
                Id = s.Id,
                Content = s.Content,
                Description = s.Description,
                PostedOn = s.PostedOn,
                Title = s.Title,
                UserId = s.UserId
            }).FirstOrDefault();
            return story;
        }


        public bool Add(string createdByUserId, StoryCreateModel newstory, List<int> groupIds)
        {
            var story = new Story();
            story.PostedOn = DateTime.Now;
            story.UserId = createdByUserId;
            story.Title = newstory.Title;
            story.Content = newstory.Content;
            story.Description = newstory.Description;
            //foreach (var group in _groupRepository.Get.Where(g => groupIds.Contains(g.Id)).ToList())
            //{
            //    story.Groups.Add(group);
            //}
             story.Groups=_groupRepository.Get.Where(g=>groupIds.Contains(g.Id)).ToList();

            try
            {
                _storyRepository.Add(story);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Edit(StoryEditModel story)
        {

            var st = _storyRepository.Get.FirstOrDefault(s=>s.Id==story.Id);

            st.Content = story.Content;
            st.Description = story.Description;
            st.Title = story.Title;
            try
            {
                _storyRepository.Update(st);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }




    }
}
