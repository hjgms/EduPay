using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduPay.Data;
using EduPay.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CursosPresenciaisController : ControllerBase
{
    private readonly APIContext _context;

    public CursosPresenciaisController(APIContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CursoPresencial>>> Get()
    {
        return await _context.Cursos
            .OfType<CursoPresencial>()
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CursoPresencial?>> GetById(int id)
    {
        var curso = await _context.Cursos
            .OfType<CursoPresencial>()
            .FirstOrDefaultAsync(c => c.Id == id);

        return curso == null ? NotFound() : curso;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CursoPresencial>> Create(CursoPresencial curso)
    {
        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = curso.Id }, curso);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, CursoPresencial curso)
    {
        if (id != curso.Id) return BadRequest();

        _context.Entry(curso).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var curso = await _context.Cursos
            .OfType<CursoPresencial>()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (curso == null) return NotFound();

        _context.Cursos.Remove(curso);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}