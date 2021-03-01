using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Models.ViewModels
{
    public class BookListViewModel
    {
        //project itself
        public IEnumerable<Book> Books { get; set; }

        //building a new model for the index page in particular
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }

    }
}
