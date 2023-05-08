using ListaConvidados.Enumerators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaConvidados.Models
{
    [Table("Convidados")]
    public class ConvidadosModel : BaseModel
    {        
        [MaxLength(400), Column("Nome"), Required]
        public string Nome { get; set; }
        [Column("Resposta"), Required(ErrorMessage ="Resposta Inválida")]
        public Resposta Resposta { get; set; }
    }
}
