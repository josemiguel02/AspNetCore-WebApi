using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Entidades;

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/libros")]
public class LibrosController : ControllerBase
{
    private readonly AppDbContext _context;

    public LibrosController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<ActionResult<List<Libro>>> Get()
    {
        return await _context.Libros.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Libro>> GetLibro(int id)
    {
        return await _context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(x => x.Id == id);
    }

    [HttpPost]
    public async Task<ActionResult> Post(Libro libro)
    {
        var existsAutor = await _context.Autores.AnyAsync(x => x.Id == libro.AutorId);

        if (!existsAutor)
        {
            return BadRequest($"No existe un autor con id: {libro.AutorId}");
        }

        _context.Add(libro);
        await _context.SaveChangesAsync();

        return Ok();
    }
}