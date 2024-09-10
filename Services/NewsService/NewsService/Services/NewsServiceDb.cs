using Microsoft.EntityFrameworkCore;
using NewsService.Models;

namespace NewsService.Services;

public class NewsServiceDb : DbContext
{
    public NewsServiceDb(DbContextOptions<NewsServiceDb> options) : base(options)
    {
    }

    public DbSet<Visit> Visits { get; set; }
}

