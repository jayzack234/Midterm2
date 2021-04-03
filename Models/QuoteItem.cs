using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm2.Models
{
    //Properties for each quote
    public class QuoteItem
    {
        //Primary Key
        [Key]
        [Required]
        public int QuoteId { get; set; }
        [Required]
        //The last two inputs are optional, whereas the first three are required
        public string Quote { get; set; }
        [Required]
        public string Author_Speaker { get; set; }
        [Required]
        public string Date { get; set; }
        public string Subject { get; set; }
        public string Citation { get; set; }
    }
}
