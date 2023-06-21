using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TimedAssignment.Services.CommentServices
{
    public class CommentService
    {
        private readonly TimedAssignmentDBContext _context;

        private readonly IMapper _mapper;
        public CommentService(TimeedAssignmentDBContext context)
        {
            _context = context;
            _mapper = _mapper;
        }

        public async Task<bool> CreateComment(CommentCreate model)
        {
            var comment = _mapper.Map<CommentEntity>(model);

            await _context.Comments.AddAsync(comment);

            return await _context.SaveChangesAsync() > 0;
        }

        public async <bool> UpdateComment(CommentEdit model)
        {
            var comment = await _context.Comments.Include(c => c.id).SingleOrDefaultAsync(x => x.id == model.id);
            
            if (Comment is null) return false;

            Comment.Id = model.Id;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment is null) return false;

            _context.Comments.Remove(comment);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<CommentDetail> GetComment(int id)
        {
            var comment = await _context.Comments.Include(c => c.id).SingleOrDefaultAsync(x => x.id == id);
            
            if (Comment is null) return new CommentDetail{};

            return _mapper.Map<CommmentDetail>(comment);
            }

        public async Task<List<CommentListItem>> GetComments()
        {
            var comments = await _context.Comments.ToListAsync();

            var categoriesListItems = _mapper.Map<List<CommentListItem>>(comments);
            
            return categoriesListItems;
        }


    }
}