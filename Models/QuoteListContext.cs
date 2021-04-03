using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Midterm2.Models
{
    //Inherits from DbContext
    public class QuoteListContext : DbContext
    {
        //constructor, bring the options into the context file
        //DbContexOptions of type QuoteListContext
        //Inherients from the base option
        public QuoteListContext (DbContextOptions<QuoteListContext> options) : base (options)
        {

        }
        //Import a table, and the type is QuoteList
        public DbSet<QuoteItem> Quotes { get; set; }
    }
}
