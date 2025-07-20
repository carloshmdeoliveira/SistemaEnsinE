using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEnsinE.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 999999.99, ErrorMessage = "Informe um valor válido para o preço.")]
        public decimal Preco { get; set; }

        [Display(Name = "Disponível?")]
        public bool Situacao { get; set; }

        [Required(ErrorMessage = "A comissão é obrigatória.")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100, ErrorMessage = "A comissão deve estar entre 0% e 100%.")]
        public decimal Comissao { get; set; }

        public ICollection<Cliente>? Clientes { get; set; }
    }
}
