using Microsoft.EntityFrameworkCore;
using MyWebApi.Entidades;

namespace MyWebApi;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }
}