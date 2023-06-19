using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data;
using TimedAssignment.Data.TimedAssignmentContext;
using TimedAssignment.Data.Entities;

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
    }
}