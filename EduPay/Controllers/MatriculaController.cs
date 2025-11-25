using System.Collections.Generic;
using System.Threading.Tasks;
using EduPay.Data;
using EduPay.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MatriculaController : ControllerBase
{
    private readonly APIContext _context;

    public MatriculaController(APIContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Matricula>>> GetMatriculas() =>
        await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Curso)
            .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Matricula?>> GetMatricula(int id)
    {
        var m = await _context.Matriculas
            .Include(m => m.Aluno)
            .Include(m => m.Curso)
            .FirstOrDefaultAsync(m => m.Id == id);

        return m == null ? NotFound() : m;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Matricula>> CriarMatricula(Matricula matricula)
    {
        _context.Matriculas.Add(matricula);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMatricula),
            new { id = matricula.Id }, matricula);
    }
}