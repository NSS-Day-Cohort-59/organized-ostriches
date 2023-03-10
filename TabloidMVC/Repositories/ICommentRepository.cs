using TabloidMVC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace TabloidMVC.Repositories
{
    public interface ICommentRepository
    {
        public List<Comment> GetAllComments();

        public List<Comment> GetCommentsByPostId(int postId);

        public Comment GetCommentById(int id);

        void AddComment(Comment comment);

        void DeleteComment(int commentId);
    }
    
        
}

