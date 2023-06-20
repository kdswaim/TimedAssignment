using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Posts
{
    public class PostListItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public Guid AuthorId { get; set; }
    }
}