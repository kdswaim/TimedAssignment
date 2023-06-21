using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Comments
{
    public class CommentEdit
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
       public string Text { get; set; } = string.Empty; 
       
        [Required]
       public Guid AuthorId { get; set; }
                  
        [Required]
       public int PostId { get; set; }

    }
}