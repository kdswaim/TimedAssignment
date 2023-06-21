using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedAssignment.Models;
using TimedAssignment.Models.Comments;

namespace TimedAssignment.Services.CommentServices
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CommentCreate model); 
        Task<bool> UpdateComment(CommentEdit model); 
        Task<bool> DeleteComment(int id); 
        Task<CommentDetail> GetComment(int id); 
        Task<List<CommentListItem>> GetComments(); 
    }
}