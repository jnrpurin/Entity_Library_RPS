using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Context : DbContext
    {
        public DbSet<Livros> Livros { get; set; }
    }
}