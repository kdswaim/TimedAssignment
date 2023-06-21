using TimedAssignment.Data.Entities;
using TimedAssignment.Models.Comments;

namespace TimedAssignment.Models.Posts
{
    public class PostDetail
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual List<CommentListItem> Comments { get; set; }

   //     public virtual List<Hate> hateList { get; set; } = new List<Hate>();

        public string AuthorId { get; set; }
    }
}