using ASPShop.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
namespace ASPShop.Data;

public class AppDbContext : DbContext
{
    public DbSet<Main> items { get; set; } = null!;
    public DbSet<Orders> orders { get; set; } = null!;
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	} 
