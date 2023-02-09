using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public string? Conteúdo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Cor? Cor { get; set; }

        [Required]
        public string? CategoriaId { get; set; }
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
