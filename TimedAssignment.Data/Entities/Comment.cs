using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimedAssignment.Data.Entities
{
    public class Comment
    {
        [Key]
       public int Id { get; set; }
       
       public string Text { get; set; } = string.Empty; 
       
       public Guid AuthorId { get; set; }
       
       public virtual List<Reply> Replies{ get; set; } = new List<Reply>();
       
       public int PostId { get; set; }

       [ForeignKey(nameof(PostId))]
       public virtual Post Post { get; set; } = new Post();
    }
}