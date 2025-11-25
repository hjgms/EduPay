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
public class AlunoController : ControllerBase
{
    private readonly APIContext _context;

    public AlunoController(APIContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos() =>
        await _context.Alunos.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Aluno?>> GetAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        return aluno == null ? NotFound() : aluno;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Aluno>> CadastrarAluno(Aluno aluno)
    {
        _context.Alunos.Add(aluno);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> AtualizarAluno(int id, Aluno aluno)
    {
        aluno.Id = id;
        _context.Entry(aluno).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);
        if (aluno == null) return NotFound();
        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}