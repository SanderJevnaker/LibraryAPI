using LibraryAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Book> Books { get; set; }
}
