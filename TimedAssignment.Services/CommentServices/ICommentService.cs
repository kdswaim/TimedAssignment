using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Services.CommentServices
{
    public interface ICommentService
    {
        Task<bool> CreateComment(CommentCreate model); 
        Task<bool> UpdateComment(CommentUpdate model); 
        Task<bool> DeleteComment(int id); 
        Task<CommentDetail> GetComment(int id); 
        Task<List<CommentListItem>> GetComments(); 
    }
}