namespace EduPay.Entities;
using System;

public class Pagamento
{
    public int Id { get; set; }
    public int MatriculaId { get; set; }
    public Matricula Matricula { get; set; }

    public DateTime DataPagamento { get; set; }
    public decimal Valor { get; set; }
    public string MetodoPagamento { get; set; }
    public string Status { get; set; }
    
    public Pagamento() {}
}