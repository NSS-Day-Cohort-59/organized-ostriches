using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Security.Claims;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;
using TabloidMVC.Repositories;

namespace TabloidMVC.Controllers
{
    [Authorize]
    public class TagController : Controller
    {
        private readonly ITagRepository _tagRepository;
        private readonly IPostRepository _postRepository;

        public TagController(ITagRepository tagRepository, IPostRepository postRepository)
        {
            _tagRepository = tagRepository;
            _postRepository = postRepository;
        }

        // GET: TagController
        public IActionResult Index()
        {
            var tags = _tagRepository.GetAllTags();
            return View(tags);
        }

        // GET: TagController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tag)
        {
            try
            {
                _tagRepository.Add(tag);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(tag);
             }
         }

        // GET: TagController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TagController/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(int id, IFormCollection //collection)
        // {
          //  try
            // {
               // return RedirectToAction(nameof(Index));
            // }
           // catch
           // {
              // return View();
           // }
        // }

        // GET: TagController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TagController/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
          //  try
            //{
            //    return RedirectToAction(nameof(Index));
           // }
           // catch
           // {
               // return View();
           // }
        // }
    }
}
