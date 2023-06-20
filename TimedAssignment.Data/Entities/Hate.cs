using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
using TimedAssignment.Data.Entities;
=======
using System.ComponentModel.DataAnnotations.Schema;

>>>>>>> Kristen
namespace TimedAssignment.Data.Entities
{
  public class Hate
    {
        [Key]
        public int Id {get; set;}
        public Guid OwnerId {get; set;}
<<<<<<< HEAD
=======
        [ForeignKey(nameof (PostId))]
>>>>>>> Kristen
        public int PostId {get; set;}
    } 
}