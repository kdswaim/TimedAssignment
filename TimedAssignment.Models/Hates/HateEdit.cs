using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedAssignment.Models.Hates
{
    public class HateEdit
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "The Title field is required.")]
        public string Title {get; set;}

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description {get; set;}
    }
}