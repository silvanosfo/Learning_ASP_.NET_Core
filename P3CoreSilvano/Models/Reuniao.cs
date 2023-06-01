using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace P3CoreSilvano.Models
{
    public class Reuniao
    {
        public int Id { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public DateTime? Data { get; set; }

        [Display(Name = "Duracao")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public int? Duracao { get; set; }

        [Display(Name = "Resumo")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string? Resumo { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }

        [Display(Name = "Funcionário")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public int FuncionarioId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
    }
}
