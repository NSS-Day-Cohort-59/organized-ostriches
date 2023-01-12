using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Security.Claims;
using TabloidMVC.Models;
using TabloidMVC.Models.ViewModels;
using TabloidMVC.Repositories;
using System;

namespace TabloidMVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            return View(categories);
        }

        public IActionResult Create() 
        {
            var categories = new Category();
        return View(categories);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            try
            {
                _categoryRepository.AddCategory(category);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return View(category);
            }
            
        }

        public IActionResult Delete(int id) 
        {
            Category category = _categoryRepository.GetCategoryById(id);

            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category category) 
        {
            try
            {
                _categoryRepository.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                return View(category);
            }
        }

        public ActionResult Edit(int id) 
        {
            Category category = _categoryRepository.GetCategoryById(id);

            if (category == null) 
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(int id, Category category) 
        {
            try
            {
                _categoryRepository.EditCategory(category);

                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                return View(category);
            }
        }

        public ActionResult Details(int id) 
        {
            Category category = _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);

        }

    }
}
