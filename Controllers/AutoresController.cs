using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using my_rest_api.Entidades;

namespace my_rest_api.Controllers;

[ApiController]
[Route("api/autores")]
public class AutoresController: ControllerBase
{
    private readonly AppDbContext _context;

    public AutoresController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Autor>>> Get()
    {
        return await _context.Autores.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult> Post(Autor autor)
    {
        _context.Add(autor);
        await _context.SaveChangesAsync();

        return Ok();
    }
}