using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ITagRepository
    {
        void Add(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(int tagId);
        List<Tag> GetAllTags();
        Tag GetTagById(int id);
    }
}
