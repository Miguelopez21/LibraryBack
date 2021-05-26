using System;
using System.Threading.Tasks;
using Entities;
using Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EntityFramework
{
    public class LibraryContext : DbContext, IContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Editorial> Editorials { get; set; }

        Task<int> IContext.SaveChangesAsync()
        {
            return SaveChangesAsync();
        }
    }
}
