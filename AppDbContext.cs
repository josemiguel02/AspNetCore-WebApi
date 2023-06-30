using Microsoft.EntityFrameworkCore;
using my_rest_api.Entidades;

namespace my_rest_api;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Autor> Autores { get; set; }
}