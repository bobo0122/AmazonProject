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
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95,
                        Page = 1488
                    },
                    new Book
                    {
                       
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Page = 944
                    },
                    new Book
                    {
                        
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Page = 832
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Page = 864

                    },
                     new Book
                     {
                         Title = "American Ulysses",
                         Author = "Ronald C. White",
                         Publisher = "Random House",
                         ISBN = "978-0812981254",
                         Classification = "Non-Fiction",
                         Category = "Biography",
                         Price = 11.61,
                         Page = 528

                     },
                      new Book
                      {
                          Title = "Unbroken",
                          Author = "Laura Hillenbrand",
                          Publisher = "Random House",
                          ISBN = "978-0812974492",
                          Classification = "Non-Fiction",
                          Category = "Biography",
                          Price = 11.61,
                          Page = 288

                      },
                      new Book
                      {
                          Title = "The Great Train Robbery",
                          Author = "Michael Crichton",
                          Publisher = "Vintage",
                          ISBN = "978-0804171281",
                          Classification = "Fiction",
                          Category = "Historical Fiction",
                          Price = 11.61,
                          Page = 304

                      }
                    );
                context.SaveChanges();
            }
        }
    }
}
