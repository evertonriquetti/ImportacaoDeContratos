using System.ComponentModel.DataAnnotations;

namespace ImportacaoDeContratos.Models
{
    public class Contratos
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int Contrato { get; set; }
        public string Produto { get; set; }
        public string Vencimento { get; set; }
        public decimal Valor { get; set; }  
    }
}
