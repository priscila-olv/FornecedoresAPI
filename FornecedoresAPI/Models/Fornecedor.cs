using FornecedoresAPI.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FornecedoresAPI.Models
{
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [StringLength(80)]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Apenas números são permitidos")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O campo telefone deve ter 11 digítos")]
        public string? Telefone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(14)]
        [CpfCnpj]
        public string? CpfCnpj { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataCadastro { get; set; }
    }
}
