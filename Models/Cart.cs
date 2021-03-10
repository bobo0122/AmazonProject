using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } =
            new List<CartLine>();
        public virtual void AddItem (Book book, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Book.BookId == book.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //remove a certain line
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);
       
        //clear all the lines
        public virtual void Clear() => Lines.Clear();
        public decimal ComputeTotalSum() => (decimal)Lines.Sum(e => 
        e.Book.Price * e.Quantity);
        
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
