
namespace TimedAssignment.Models.Posts
{
    public class PostDetail
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual List<Comment> comments { get; set; } = new List<Comment>();

        public virtual List<Hate> hateList { get; set; } = new List<Hate>();

        public Guid AuthorId { get; set; }
    }
}