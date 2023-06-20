using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using TimedAssignment.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimedAssignment.Data.Entities
{
  public class Hate
    {
        [Key]
        public int Id {get; set;}
        public Guid OwnerId {get; set;}

        [ForeignKey(nameof (PostId))]
        public int PostId {get; set;}
    } 
}