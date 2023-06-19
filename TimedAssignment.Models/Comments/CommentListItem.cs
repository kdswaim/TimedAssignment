using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models
{
    public class CommentListItem
    {
        public int Id { get; set; }
       
       public string Text { get; set; } = string.Empty; 
       
       public Guid AuthorId { get; set; }
    }
}