using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Mobile { get; set; }
    }
}
