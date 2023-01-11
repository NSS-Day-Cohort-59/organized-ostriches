using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabloidMVC.Repositories;
using System.Collections.Generic;
using TabloidMVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;

namespace TabloidMVC.Controllers
{
    public class CommentsController : Controller
    {

        private readonly ICommentRepository _commentRepo;

        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepo = commentRepository;
        }


        // GET: CommentsController
        public ActionResult Index(int postId)
        {
            List<Comment> comments = _commentRepo.GetAllComments();

            return View(comments);
        }

        // GET: CommentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CommentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            try
            {
                
                comment.CreateDateTime = DateTime.Now;
                comment.UserProfileId = GetCurrentUserProfileId();
                comment.PostId = 1; 

                _commentRepo.AddComment(comment);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(comment);
            }
        }

        // GET: CommentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CommentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CommentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private int GetCurrentUserProfileId()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }

       
    }
}
