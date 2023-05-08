using System.ComponentModel.DataAnnotations;

namespace ListaConvidados.Models
{
    public class BaseModel
    {
        [Key]
        public int Identificador { get; set; }
    }
}
