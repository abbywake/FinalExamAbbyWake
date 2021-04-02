using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamAbbyWake.Models
{
    public class Quotes
    {
        //database. Making the Quote the Id, and then making all of the required objects required. 
        //adding a ? to make the others nullable. 
        [Key]
        public int QuoteId { get; set; }
        [Required]
        public string Quote { get; set; }
        [Required]
        public string AuthorFName { get; set;}
        [Required]
        public string AuthorLName { get; set; }
        [Required]
        public DateTime Date { get; set; }
       
        public string? Subject { get; set; } 
        
        public string? Citation { get; set; }

    }
}
