using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Título")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Conteúdo")]
        public string? Conteudo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Cor? Cor { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }

        [Required]
        public string? AspNetUserId { get; set; }
        public IdentityUser? AspNetUser { get; set; }
    }

    public enum Cor
    {
        Azul,
        Cinza,
        Verde,
        Vermelho,
        Amarelo,
        Branco,
        Preto
    }
}
