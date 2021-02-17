using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            AmazonDbContext context =
                application.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AmazonDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        
                        Title = "Les Miserable",
                        Author = "Victor Hugo",
                        Publisher= "Signet",
                        ISBN = "978-0451419439",
                        Classification_Category = "Fiction, Classic",
                        Price = 9.95
                    },
                    new Book
                    {
                       
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification_Category = "Non-Fiction, Biography",
                        Price = 14.58
                    },
                    new Book
                    {
                        
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification_Category = "Non-Fiction, Biography",
                        Price = 21.54
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification_Category = "Non-Fiction, Biography",
                        Price = 11.61
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
