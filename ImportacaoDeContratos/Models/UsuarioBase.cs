using System.ComponentModel.DataAnnotations;

namespace ImportacaoDeContratos.Models
{
    public class UsuarioBase
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}