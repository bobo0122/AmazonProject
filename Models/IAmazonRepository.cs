using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazonProject.Models;

namespace AmazonProject.Models
{
    //INTERFACE!!!!
    public interface IAmazonRepository
    {
        IQueryable<Book> Books { get; }
    }
}


