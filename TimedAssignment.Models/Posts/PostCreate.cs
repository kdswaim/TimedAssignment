using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TimedAssignment.Models.Posts
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        // [Required]
        // public string AuthorId { get; set; }
    }
}