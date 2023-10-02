using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi.Entidades;

namespace MyWebApi.Controllers;

[ApiController]
[Route("api/autores")]
public class AutoresController : ControllerBase
{
    private readonly AppDbContext _context;

    public AutoresController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Autor>>> Get()
    {
        return await _context.Autores.Include(x => x.Libros).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Post(Autor autor)
    {
        _context.Add(autor);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(Autor autor, int id)
    {
        if (autor.Id != id)
        {
            return BadRequest("El id del autor no coincide con el id de la URL");
        }

        var exists = await _context.Autores.AnyAsync(x => x.Id == id);

        if (!exists)
        {
            return NotFound();
        }

        _context.Update(autor);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var exists = await _context.Autores.AnyAsync(x => x.Id == id);

        if (!exists)
        {
            return NotFound();
        }

        _context.Remove(new Autor() { Id = id });
        await _context.SaveChangesAsync();

        return Ok();
    }
}