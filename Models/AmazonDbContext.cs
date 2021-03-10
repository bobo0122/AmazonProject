using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AmazonProject.Models
{
    public class AmazonDbContext: DbContext
    {
        public AmazonDbContext(DbContextOptions<AmazonDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        //pull in another table
        //public DbSet<Author> Author { get; set; }
    }
}
