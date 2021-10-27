using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }
        public ICollection<IssueDetails> IssueDetails { get; set; }

    }
}
