using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStories.Core;
using Microsoft.AspNet.Identity;
using UserStories.Core.Models;

namespace UserStories.Controllers
{
    [Authorize]
    public class StoryController : Controller
    {
       private readonly IStoryService _storyService;
       private readonly IGroupService _groupService;
      public StoryController(IStoryService storyService, IGroupService groupService)
        {
            _storyService = storyService;
            _groupService = groupService;
        }
        public ActionResult Index()
        {
            var userStories = _storyService.GetByUserId(User.Identity.GetUserId());
            return View(userStories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var groups= _groupService.GetByUserId(User.Identity.GetUserId()).ToList();
            return View(new StoryCreateModel(){ Groups= groups});
        }
        [HttpPost]
        public ActionResult Create(StoryCreateModel model, List<int> groups)
        {
            if (true || ModelState.IsValid)
            {
                model.Groups = groups.Select(id => new GroupSelectModel() { Id=id}).ToList();
                _storyService.Add(User.Identity.GetUserId(), model,groups);
                return RedirectToAction("Index");

            }
            else
            {
                return View(model);
            }

        }
        public ActionResult Details(int id)
        {
          var story=  _storyService.GetById(id);
            return View(story);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var story = _storyService.GetById(id);
            StoryEditModel toedit= new StoryEditModel();
            toedit.Id = story.Id;
            toedit.Content=story.Content;
            toedit.Description=story.Description;
            toedit.Title=story.Title;

            return View(toedit);
        }
        [HttpPost]
        public ActionResult Edit(StoryEditModel model)
        {
            if (ModelState.IsValid)
            {
                _storyService.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}