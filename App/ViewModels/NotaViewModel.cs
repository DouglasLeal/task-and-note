using App.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.ViewModels
{
    public class NotaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Título")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Conteúdo")]
        public string? Conteúdo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Cor? Cor { get; set; }

        [Required]
        [DisplayName("Categoria")]
        public string? CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

        public string? AspNetUserId { get; set; }
        public IdentityUser? AspNetUser { get; set; }
    }
}
