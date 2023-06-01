using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EquiMembros2023.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "(6) Data registo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "(5) Nome cliente (obrigatório, máx: 100carateres)")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "Máximo 100 carateres.")]
        public string? NomeCliente { get; set; }

        [Display(Name = "(4) Digitar email: .+\\@.+\\..+")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Email inválido...")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "(3) Utilizador (4 a 10 letras): [a-zA-Z]+")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Apenas alfabeto")]
        [StringLength(10, MinimumLength = 4)]
        public string BdUser { get; set; }

        [Required]
        [Display(Name = "(2) Senha (de 4 a 10 carateres: [StringLength(10, MinimumLength = 4)]")]
        [StringLength(10, MinimumLength = 4)]
        public string? Password { get; set; }

        [Required]
        [Display(Name = "(1) Idade entre 18 e 65: [Range(18, 65)]")]
        [Range(18, 65)]
        public int Idade { get; set; }

        [Display(Name = "(12) BRAGA ou PORTO ou LISBOA, vírgula espaço, 2 dígitos: BRAGA|PORTO|LISBOA, [0-9]{2} ")]
        [RegularExpression("(BRAGA|PORTO|LISBOA), [0-9]{2}", ErrorMessage = "Ex.: BRAGA, 33 ou LISBOA, 12")]
        public string? Cidade { get; set; }

        [Display(Name = "(11) Código postal XXXXX dddd-ddd: [A-Z]+ [0-9]{4}-[0-9]{3} ")]
        [RegularExpression("[A-Z]+ [0-9]{4}-[0-9]{3}", ErrorMessage = "Ex.: BRAGA 4700-999")]
        public string? CodPostal { get; set; }

        [Display(Name = "(10) Apenas dígitos, pelo menos 1: [0-9]+ ")]
        [RegularExpression("[0-9]+", ErrorMessage = "Apenas dígitos")]
        public string? ApenasDigitos { get; set; }

        [Display(Name = "(9) Apenas letras maiúsculas, pode ser vazio: [A-Z]* ")]
        [RegularExpression("[A-Z]*", ErrorMessage = "Apenas maiúsculas ou vazio")]
        public string? ApenasMaiusculas { get; set; }

        [Display(Name = "(8) Começa com BRG e a seguir quaisquer carateres -> BRG.* ")]
        [RegularExpression("BRG.*", ErrorMessage = "BRG seguido de quaisquer carateres")]
        public string? BRGeQqCarater { get; set; }

        [Required]
        [Display(Name = "(7) Preço (C# double->SQL float): [0-9]+,[0-9]{2}")]
        [RegularExpression("[0-9]+.[0-9]{2}", ErrorMessage = "Ex.: 10,00")]
        public double PrecoProduto { get; set; }

        [Required]
        [Display(Name = "(7b) Preço (C# decimal->SQL decimal): [0-9]+,[0-9]{2}")]
        [RegularExpression("[0-9]+.[0-9]{2}", ErrorMessage = "Ex.: 10,00")]
        public decimal PrecoProdutoB { get; set; }
    }
}
