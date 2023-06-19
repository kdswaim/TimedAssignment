using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models
{
    public class CommentCreate
    {
        public string Text { get; set; } = string.Empty; 
       
       public Guid AuthorId { get; set; }
                     
       public int PostId { get; set; }
    }
}