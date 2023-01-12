using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ITagRepository
    {
        void Add(Tag tag);
        List<Tag> GetAllTags();
    }
}
