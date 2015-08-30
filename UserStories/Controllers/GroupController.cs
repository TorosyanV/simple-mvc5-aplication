using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserStories.Core;
using UserStories.Core.Models;
using Microsoft.AspNet.Identity;
using UserStories.Models;

namespace UserStories.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {
        IGroupService _groupService;
        IStoryService _storyService;
        public GroupController(IGroupService groupService, IStoryService storyService)
        {
            _groupService = groupService;
            _storyService = storyService;
        }
        // GET: Group
        public ActionResult Index()
        {
            var groups = _groupService.GetAll();

            return View(groups);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(GroupCreateModel group)
        {
            if (ModelState.IsValid)
            {
                _groupService.Add(group, User.Identity.GetUserId());
                return RedirectToAction("Index");
            }
            return View(group);
        }
        public ActionResult Stories(int id)
        {
          var stories=  _groupService.GetStoriesByGroupId(id);

            return View(stories);
        }
        public ActionResult Members(int id)
        {
            var users=_groupService.GetMemborsByGroupId(id);
            return View(users);
        }

        public ActionResult Details(int id)
        {
           var group= _groupService.GetById(id,User.Identity.GetUserId());
            return View(group);
        }
        [HttpPost]
        public JsonResult Join(int groupId)
        {
            _groupService.JoinGroup(User.Identity.GetUserId(), groupId);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Leave(int groupId)
        {
            _groupService.LeaveGroup(User.Identity.GetUserId(), groupId);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}