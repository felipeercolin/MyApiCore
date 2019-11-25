using System;
using System.ComponentModel.DataAnnotations;

namespace MyApiCore.Model
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres.")]
        public string Documento { get; set; }
        public int TipoFornecedor { get; set; }
        public bool Ativo { get; set; }
    }
}
