using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEnsinE.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome completo pode ter no máximo 150 caracteres.")]
        [Display(Name = "Nome Completo")]
        public required string NomeCompleto { get; set; }

        [Phone(ErrorMessage = "Informe um telefone válido.")]
        [StringLength(20, ErrorMessage = "O telefone pode ter no máximo 20 caracteres.")]
        public string? Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [StringLength(100, ErrorMessage = "O e-mail pode ter no máximo 100 caracteres.")]
        public string? Email { get; set; }

        [Range(0, 100, ErrorMessage = "O desconto deve estar entre 0% e 100%.")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Desconto { get; set; }

        [StringLength(100, ErrorMessage = "O nome do vendedor pode ter no máximo 100 caracteres.")]
        public string? Vendedor { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório.")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto? Produto { get; set; }
    }
}
