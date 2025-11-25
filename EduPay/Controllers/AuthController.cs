using System.Threading.Tasks;
using EduPay.Data;
using EduPay.DTO;
using EduPay.Entities;
using EduPay.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduPay.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly APIContext _context;
    private readonly SenhaService _senhaService;
    private readonly JwtService _jwtService;

    public AuthController(APIContext context, SenhaService senhaService, JwtService jwtService)
    {
        _context = context;
        _senhaService = senhaService;
        _jwtService = jwtService;
    }

    [HttpPost("registrar")]
    public async Task<IActionResult> Registrar(UsuarioRegistrarDTO dto)
    {
        if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
            return BadRequest("E-mail já cadastrado.");

        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Email = dto.Email,
            SenhaHash = _senhaService.GerarHash(dto.Senha)
        };

        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok("Usuário registrado com sucesso.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UsuarioLoginDTO dto)
    {
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (usuario == null)
            return Unauthorized("Credenciais inválidas.");

        if (!_senhaService.ValidarSenha(dto.Senha, usuario.SenhaHash))
            return Unauthorized("Credenciais inválidas.");

        var token = _jwtService.GerarToken(usuario);

        return Ok(new { token });
    }
}