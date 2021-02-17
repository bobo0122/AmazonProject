using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class EFAmazonRepository : IAmazonRepository
    {
        public AmazonDbContext _context;

        //Constructor
        public EFAmazonRepository(AmazonDbContext context)
        {
            _context = context;
        }

        //         set => what is in the projects
        // this directly calls the CharityDbContext.cs 
        public IQueryable<Book> Books => _context.Books;

    }
}
