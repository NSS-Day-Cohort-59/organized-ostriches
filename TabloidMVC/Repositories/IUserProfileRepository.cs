using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetByEmail(string email);
        public List<UserProfile> GetAll();

        public UserProfile GetUserById(int id);
    }


}