using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Data.TimedAssignmentContext;
using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Hates;

namespace TimedAssignment.Services.HateServices
{

    public class HateService
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

        public Hate CreateHate(HateCreate hateCreate)
        {
            var newHate = new Hate
            {
                Title = hateCreate.Title,
                Description = hateCreate.Description,
            };
            _context.Hates.Add(newHate);
            _context.SaveChanges();

            return newHate;
        }

        public List<Hate> Get HatesByPostId(int postId)
        {
            var hates = _context.Hates.Where(h => h.PostId == postId).ToList();
            return hates;
        }
        public List<Hate> GetHatesByOwnerId(string ownerId)
        {
            var hates = _context.Hates.Where(h => h.OwnerId == ownerId).ToList();
            return hates;
        }

        public Hate UpdateHate(int hateId, HateEdit hateEdit)
        {
            var existingHate = _context.Hates.FirstOrDefault(h => h.Id == hateId);
            if (existingHate != null)
            {
                existingHate.Title = hateEdit.Title;
                existingHate.Description = hateEdit.Description;

                _context.SaveChanges();
            }

            return existingHate;
        }

        public void DeleteHate(int hateId)
        {
            var existingHate = _context.Hates.FirstOrDefault(h => h.Id == hateId);

            if (existingHate != null)
            {
                _context.Hates.Remove(existingHate);
                _context.SaveChanges();
            }
        }
    }
}
}