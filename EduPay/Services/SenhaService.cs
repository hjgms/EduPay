using System;
using System.Security.Cryptography;
using System.Text;

namespace EduPay.Services;

public class SenhaService
{
    public string GerarHash(string senha)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
        return Convert.ToBase64String(bytes);
    }

    public bool ValidarSenha(string senha, string hash)
    {
        return GerarHash(senha) == hash;
    }
}