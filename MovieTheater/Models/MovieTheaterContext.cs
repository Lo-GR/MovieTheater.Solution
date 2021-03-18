using Microsoft.EntityFrameworkCore;

namespace MovieTheater.Models
{
  public class MovieTheaterContext : DbContext
  {
    public DbSet<Customer> Customers {get; set;}
    public DbSet<Movie> Movies {get; set;}
    public DbSet<CustomerMovie> CustomerMovie {get; set;}
    public MovieTheaterContext(DbContextOptions options) : base(options){}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}