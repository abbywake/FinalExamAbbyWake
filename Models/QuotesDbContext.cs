using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExamAbbyWake.Models
{
    //quotes DbContext to make everything accessible. 
    public class QuotesDbContext : DbContext 
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Quotes> Quotes1 { get; set; }

}
}
