using ListaConvidados.Enumerators;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ListaConvidados.DTOs
{
    public class AdicionarConvidadoDTO
    {
        [MaxLength(400), Column("Nome"), Required]
        public string Nome { get; set; }
        [Column("Resposta"), Required(ErrorMessage = "Resposta Inválida")]
        public Resposta Resposta { get; set; }
    }
}
