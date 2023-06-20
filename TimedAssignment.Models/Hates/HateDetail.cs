using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Hates
{
    public class HateDetail
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public DateTime CreatedAt {get; set;}
        public string UserName {get; set;}
    }
}