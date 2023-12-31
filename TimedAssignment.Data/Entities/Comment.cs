using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data.Entities
{
    public class Comment
    {
        [Key]
       public int Id { get; set; }
       
       public string Text { get; set; } = string.Empty; 
       
       public Guid AuthorId { get; set; }
       
       public int PostId { get; set; }

       [ForeignKey(nameof(PostId))]
       public virtual Post Post { get; set; }
       
    //    public List<Reply> Replies{ get; set; }
    }
}