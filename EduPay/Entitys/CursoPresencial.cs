namespace EduPay.Entities;

public class CursoPresencial : Curso
{
    public string Local { get; set; }
    public string Sala { get; set; }
    public int Capacidade { get; set; }
    
    public CursoPresencial() {}
}