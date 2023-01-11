using TabloidMVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace TabloidMVC.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IConfiguration _config;

        public CommentRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Comment> GetAllComments()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand()) 
                {
                    cmd.CommandText = @"
                        SELECT Id, PostId, UserProfileId, Subject, Content, CreateDateTime
                        FROM Comment";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    { 
                        List<Comment> comments = new List<Comment>();
                        while (reader.Read())
                        {

                            Comment comment = new Comment
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                                Subject = reader.GetString(reader.GetOrdinal("Subject")),
                                Content = reader.GetString(reader.GetOrdinal("Content")), 
                                CreateDateTime = reader.GetString(reader.GetOrdinal("CreateDateTime")),
                            };
                            comments.Add(comment);

                        }
                            return comments;
                    }
                }

            }
        }
        public List<Comment> GetCommentsByPostId(int PostId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                           SELECT c.Id, c.PostId, c.UserProfileId, c.Subject, c.Content, c.CreateDateTime
                          FROM Comment c
                          LEFT JOIN Post p ON p.Id = c.PostId 
                          WHERE c.PostId = @Id";


                    cmd.Parameters.AddWithValue("@Id", PostId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Comment> comments = new List<Comment>();
                        while (reader.Read())
                        {

                                Comment comment = new Comment
                                {

                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    PostId = reader.GetInt32(reader.GetOrdinal("PostId")),
                                    UserProfileId = reader.GetInt32(reader.GetOrdinal("UserProfileId")),
                                    Subject = reader.GetString(reader.GetOrdinal("Subject")),
                                    Content = reader.GetString(reader.GetOrdinal("Content")),
                                    CreateDateTime = reader.GetString(reader.GetOrdinal("CreateDateTime")),
                                };


                            comments.Add(comment);
                        }
                        return comments;


                    }
                }
            }
        }
    }
}
