using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{

    public class BookIssueDetails
    {

        [Key]
        public int id { get; set; }
        public int IssueId { get; set; }
        public string Title { get; set; }

        public string StudentName { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }


    }
}
