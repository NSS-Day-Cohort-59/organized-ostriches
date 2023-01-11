using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration config) : base(config) { }
        public List<Category> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, name FROM Category Order By Name";
                    var reader = cmd.ExecuteReader();

                    var categories = new List<Category>();

                    while (reader.Read())
                    {
                        categories.Add(new Category()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("name")),
                        });
                    }

                    reader.Close();

                    return categories;
                }
            }
        }

        public void AddCategory(Category category)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Category (Name)
                    OUTPUT INSERTED.ID
                    Values(@name)";

                    cmd.Parameters.AddWithValue("@name", category.Name);

                    int id = (int)cmd.ExecuteScalar();

                    category.Id = id;
                }
            }
        }

        public Category GetCategoryById(int id) 
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Select Id, Name
                        From Category
                        WHERE Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        if (reader.Read())
                        {
                            Category category = new Category
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name"))
                            };
                            return category;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void DeleteCategory (int categoryId) 
        { 
            using (SqlConnection conn = Connection) 
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        Delete From Category
                        Where Id = @id
                        ";

                    cmd.Parameters.AddWithValue("@id", categoryId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
