using System.Collections.Generic;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IHashtagRepository
    {
        IEnumerable<Hashtag> GetAllHashtags();
        IEnumerable<Hashtag> GetHashtagsByIds(int minId, int maxId);
        Hashtag GetHashtagById(int hashtagId);
        Hashtag AddHashtag(Hashtag hashtag);
        Hashtag UpdateHashtag(Hashtag hashtag);
        Hashtag DeleteHashtag(int hashtagId);
    }
}
