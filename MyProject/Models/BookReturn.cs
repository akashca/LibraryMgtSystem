using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class BookReturn
    {
        [Key]
        public int IssueId { get; set; }
        public string Title { get; set; }

        public string StudentName { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Elap { get; set; }
        public int Fine { get; set; }

    }
}
