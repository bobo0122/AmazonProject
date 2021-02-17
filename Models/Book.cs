using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int BookId { get; set; }

        [Required]
        public string Title  { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{10})$", ErrorMessage = "Invalid ISBN, please re-enter a 13-digit number. ")]
        public string ISBN { get; set; }
        [Required]
        public string Classification_Category { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
