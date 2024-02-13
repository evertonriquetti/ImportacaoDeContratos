using System.ComponentModel.DataAnnotations;

namespace ImportacaoDeContratos.Models
{
    public class Importado
    {
        public Importado(string nomeArquivo, int usuarioId) 
        { 
            NomeArquivo = nomeArquivo;
            UsuarioId = usuarioId;
        }

        [Key]
        public int Id { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataImportacao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}