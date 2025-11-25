namespace EduPay.Entities;

public abstract class Curso
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public int DuracaoHoras { get; set; }
}
