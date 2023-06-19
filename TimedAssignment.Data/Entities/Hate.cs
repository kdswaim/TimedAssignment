using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Data.Entities
{
  public class Hate
    {
        public int Id {get; set;}
        public int PostId {get; set;}
        public Guid OwnerId {get; set;}
    } 
}