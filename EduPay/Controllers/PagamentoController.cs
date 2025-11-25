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
public class PagamentoController : ControllerBase
{
    private readonly APIContext _context;

    public PagamentoController(APIContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pagamento>>> GetPagamentos() =>
        await _context.Pagamentos
            .Include(p => p.Matricula)
            .ThenInclude(m => m.Aluno)
            .ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Pagamento?>> GetPagamento(int id)
    {
        var pagamento = await _context.Pagamentos
            .Include(p => p.Matricula)
            .ThenInclude(m => m.Aluno)
            .FirstOrDefaultAsync(p => p.Id == id);

        return pagamento == null ? NotFound() : pagamento;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Pagamento>> CriarPagamento(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPagamento),
            new { id = pagamento.Id }, pagamento);
    }
}