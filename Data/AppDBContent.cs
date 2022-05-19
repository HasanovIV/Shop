using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Models;

namespace Shop.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) :base(options)
        {

        }

        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
