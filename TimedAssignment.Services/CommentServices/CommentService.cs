using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models;
using TimedAssignment.Models.Comments;
using TimedAssignment.Data.TimedAssignmentContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimedAssignment.Data.Entities;

namespace TimedAssignment.Services.CommentServices
{
    public class CommentService: ICommentService
    {
        private readonly TimedAssignmentDBContext _context;

        private readonly IMapper _mapper;
        public CommentService(TimedAssignmentDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> CreateComment(CommentCreate model)
        {
            var comment = _mapper.Map<Comment>(model);

            await _context.Comments.AddAsync(comment);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateComment(CommentEdit model)
        {
            var comment = await _context.Comments.Include(c => c.Post).SingleOrDefaultAsync(x => x.Id == model.Id);
            
            if (comment is null) return false;

            comment.Id = model.Id;
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
            var comment = await _context.Comments.Include(c => c.Post).SingleOrDefaultAsync(x => x.Id == id);
            
            if (comment is null) return new CommentDetail{};

            return _mapper.Map<CommentDetail>(comment);
            }

        public async Task<List<CommentListItem>> GetComments()
        {
            var comments = await _context.Comments.ToListAsync();

            var categoriesListItems = _mapper.Map<List<CommentListItem>>(comments);
            
            return categoriesListItems;
        }


    }
}