using AmazonProject.Models;
using AmazonProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IAmazonRepository _repository;

        //we want 5 items per page 
        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, IAmazonRepository repository)
        {
            _logger = logger;
            _repository = repository;

        }

        //paging info 
        public IActionResult Index(string category, int page = 1)
        {
            return View(new BookListViewModel
            {
                Books = _repository.Books
                .Where(b => category == null || b.Category == category )
                .OrderBy(p => p.BookId)
               .Skip((page - 1) * PageSize)
               .Take(PageSize)
               ,PagingInfo = new PagingInfo
               {
                   CurrentPage = page,
                   ItemsPerPage = PageSize,
                   TotalNumItems =category ==null ? _repository.Books.Count():
                   _repository.Books.Where(x => x.Category == category).Count()
      
               },
                //CurrentCategory is declared in the BookListViewModels
                CurrentCategory = category
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
