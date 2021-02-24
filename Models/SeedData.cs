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
                        PageNo = 1488
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
                        PageNo = 944
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
                        PageNo = 832
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
                        PageNo = 864

                    },
                     new Book
                     {
                         Title = "Deep Work",
                         Author = "Cal Newport",
                         Publisher = "Grand Central Publishing",
                         ISBN ="978-1455586691",
                         Classification = "Non-Fiction",
                         Category = "Self-Help",
                         Price = 14.99,
                         PageNo = 304

                     },
                      new Book
                      {
                          Title = "Unbroken",
                          Author = "Laura Hillenbrand",
                          Publisher = "Random House",
                          ISBN = "978-0812974492",
                          Classification = "Non-Fiction",
                          Category = "Biography",
                          Price = 13.33,
                          PageNo = 288

                      },
                      new Book
                      {
                          Title = "The Great Train Robbery",
                          Author = "Michael Crichton",
                          Publisher = "Vintage",
                          ISBN = "978-0804171281",
                          Classification = "Fiction",
                          Category = "Historical Fiction",
                          Price = 15.95,
                          PageNo = 304

                      },
                        new Book
                        {
                            Title = "It's Your Ship",
                            Author = "Michael Abrashoff",
                            Publisher = "Grand Central Publishing",
                            ISBN = "978-1455523023",
                            Classification = "Fiction",
                            Category = "Self-Help",
                            Price = 21.66,
                            PageNo = 240
                         },
                         new Book
                           {
                            Title = "The Virgin Way",
                            Author = "Richard Branson",
                            Publisher = "Portfolio",
                            ISBN = "978-1591847984",
                            Classification = "Non-Fiction",
                            Category = "Business",
                            Price = 29.16,
                            PageNo = 400
                        },
                          new Book
                          {
                              Title = "Syncamore Row",
                              Author = "John Grisham",
                              Publisher = "Bantam",
                              ISBN = "978-0553393613",
                              Classification = "Fiction",
                              Category = "Thrillers",
                              Price = 15.03,
                              PageNo = 642
                          },
                          //my three fav books are the following
                           new Book
                           {
                               Title = "The Count of Monte Cristo",
                               Author = "Alexandre Dumas",
                               Publisher = "Penguin Books Ltd",
                               ISBN = "978-1593081515",
                               Classification = "Fiction",
                               Category = "Romance",
                               Price = 16,
                               PageNo = 640
                           },
                            new Book
                            {
                                Title = "The Way of Kings",
                                Author = "Brandon Sanderson",
                                Publisher = "Tor Books",
                                ISBN = "978-1448792757",
                                Classification = "Fiction",
                                Category = "Fantasy",
                                Price = 15.03,
                                PageNo = 642
                            },
                             new Book
                             {
                                 Title = "Wuthering Heights",
                                 Author = "Emily Brontë",
                                 Publisher = "Thomas Cautley Newby",
                                 ISBN = "978-0141040356",
                                 Classification = "Fiction",
                                 Category = "Novel",
                                 Price = 6.19,
                                 PageNo = 384
                             }

                    );
                context.SaveChanges();
            }
        }
    }
}
