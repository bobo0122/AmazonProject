using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AmazonProject.Models;
using AmazonProject.Infrastructure;

namespace AmazonProject.Pages
{
    public class CartModel : PageModel
    {
        private IAmazonRepository repository;

        //Constructor
        public CartModel (IAmazonRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
       
        //Methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Book book = repository.Books
                .FirstOrDefault(b => b.BookId == bookId);
           //from the local class'
           // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
           Cart.AddItem(book, 1);
          // HttpContext.Session.SetJson("cart", Cart);
            //setting the return url
            return RedirectToPage(new { returnUrl = returnUrl });

        }
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }

}
