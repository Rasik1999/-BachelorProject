using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Models
{
    public class HashtagRepository : IHashtagRepository
    {
        private readonly ContextDB _context;

        public HashtagRepository(ContextDB context)
        {
            _context = context;
        }

        public Hashtag AddHashtag(Hashtag hashtag)
        {
            var addedHashtag = _context.Hashtags.Add(hashtag);
            _context.SaveChanges();
            return addedHashtag.Entity;
        }

        public Hashtag DeleteHashtag(int hashtagId)
        {
            var foundedHashtag = _context.Hashtags.FirstOrDefault(e => e.HashtagId == hashtagId);
            if (foundedHashtag == null) return null;

            var deletedHashtag = _context.Hashtags.Remove(foundedHashtag);
            _context.SaveChanges();

            return deletedHashtag.Entity;
        }

        public IEnumerable<Hashtag> GetAllHashtags()
        {
            return _context.Hashtags;
        }

        public IEnumerable<Hashtag> GetHashtagsByIds(int minId, int maxId)
        {
            return _context.Hashtags.Where(x => x.HashtagId >= minId && x.HashtagId <= maxId);
        }

        public Hashtag GetHashtagById(int hashtagId)
        {
            return _context.Hashtags.FirstOrDefault(x => x.HashtagId == hashtagId);
        }

        public Hashtag UpdateHashtag(Hashtag hashtag)
        {
            var foundedHashtag = _context.Hashtags.FirstOrDefault(e => e.HashtagId == hashtag.HashtagId);

            if (foundedHashtag != null)
            {
                foundedHashtag.Name = hashtag.Name;

                _context.SaveChanges();

                return foundedHashtag;
            }

            return null;
        }
    }
}
