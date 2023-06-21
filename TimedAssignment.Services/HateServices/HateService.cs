using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data.TimedAssignmentContext;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Hates;

namespace TimedAssignment.Services.HateServices
{
    public class HateService : IHateService
    {
        private readonly TimedAssignmentDBContext _context;

        public HateService(TimedAssignmentDBContext context)
        {
            _context = context;
        }

        public async Task<List<Hate>> GetAllHates()
        {
            var hates = await _context.Hates.ToListAsync();
            return hates;
        }

        public Hate CreateHate (HateCreate hateCreate)
        {
            var newHate = new Hate
            {
                OwnerId = hateCreate.OwnerId,
                PostId = hateCreate.PostId
            };

            _context.Hates.Add(newHate);
            _context.SaveChanges();

            return newHate;
        }       

        public List<Hate> GetHatesByPostId(int postId)
        {
            var hates = _context.Hates.Where(h => h.PostId == postId).ToList();
            return hates;
        }

        public List<Hate> GetHatesByOwnerId(Guid ownerId)
        {
            var hates = _context.Hates.Where(h => h.OwnerId == ownerId).ToList();
            return hates;
        }

        public Hate UpdateHate(int hateId, HateEdit hateEdit)
        {
            var hate = _context.Hates.Find(hateId);

            hate.PostId = hateEdit.postId;

            _context.SaveChanges();

            return hate;
        }

        public void DeleteHate(int hateId)
        {
            var hate = _context.Hates.Find(hateId);

            _context.Hates.Remove(hate);
            _context.SaveChanges();
        }
    }                          
} 