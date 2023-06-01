using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P3CoreSilvano.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Display(Name = "Nome funcionário")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string? NomeFunc { get; set; }

        //para a entidade Reuniao:
        public virtual ICollection<Reuniao>? Reunioes { get; set; }
    }
}
