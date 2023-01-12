using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        void AddCategory(Category category);

        void DeleteCategory(int categoryId);

        public Category GetCategoryById(int id);

        void EditCategory(Category category);
    }
}