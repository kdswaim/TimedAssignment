using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        public virtual List<Hate> hateList { get; set; } = new List<Hate>();

        public string AuthorId { get; set; }
    }
}