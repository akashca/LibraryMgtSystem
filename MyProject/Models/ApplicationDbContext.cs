using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<IssueDetails> IssueDetails { get; set; }
        public DbSet<BookReturn> BookReturn { get; set; }
        
        public DbSet<BookIssueDetails> BookIssueDetails { get; set; }

    }
}
