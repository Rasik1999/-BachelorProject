using System.Collections.Generic;
using System.Threading.Tasks;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public interface IHashtagRepository
    {
        IEnumerable<Hashtag> GetAllHashtags();
        Task<List<Hashtag>> GetHashtagsByIds(int minId, int maxId);
        Hashtag GetHashtagById(int hashtagId);
        Hashtag AddHashtag(Hashtag hashtag);
        Hashtag UpdateHashtag(Hashtag hashtag);
        Hashtag DeleteHashtag(int hashtagId);
    }
}
