namespace EduPay.Entities;

public class CursoOnline : Curso
{
    public string Plataforma { get; set; }
    public string UrlAcesso { get; set; }
    public bool GravacoesDisponiveis { get; set; }
    
    public CursoOnline() {}
}