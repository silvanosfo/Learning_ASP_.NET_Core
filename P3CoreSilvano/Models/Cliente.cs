using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P3CoreSilvano.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Nome cliente")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string? NomeCliente { get; set; }

        //para a entidade item:
        public virtual ICollection<Reuniao>? Reunioes { get; set; }
    }
}
