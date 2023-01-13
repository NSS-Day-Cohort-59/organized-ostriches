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
        public ActionResult Index(int id)
        {
            // ViewData is a dictionary of objects that are stored and retrieved using strings as keys; used to transfer data from Controller to View. Since ViewData is a dictionary,
            // each key must be a string. ViewData only transfers data from controller to view, not vice-versa. It is valid only during the current request. 
            // Here, "PostId" is the key string, and assigned the value of "id", which was passed into index as a parameter.
            ViewData["PostId"] = id;   

            List<Comment> comments = _commentRepo.GetCommentsByPostId(id); 

            return View(comments);
        }

        // GET: CommentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CommentsController/Create
        public ActionResult Create(int postId)
        {
            Comment comment = new Comment();
            comment.PostId = postId;
            return View(comment);
        }

        // POST: CommentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int postId, Comment comment)
        {
            try
            {
                
                comment.CreateDateTime = DateTime.Now;
                comment.UserProfileId = GetCurrentUserProfileId();  //THANKS REBEKA!
                comment.PostId = postId; 

                _commentRepo.AddComment(comment);

                // Redirects to the specified action using the action name and route values.
                // Here, the action name is "Index," and the route value is id, 
                // assigned the value of postId, which was passed as a parameter to the Create method.
                return RedirectToAction("Index", new { id = postId }); 
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
        public ActionResult Edit(int id, Comment comment)
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
        public ActionResult Delete(int id, Comment comment)
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
