using AmazonProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonProject.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IAmazonRepository repository;
        public NavigationMenuViewComponent(IAmazonRepository r)
        {
            repository = r;
        }

        //we want to drop the partial view here 
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
