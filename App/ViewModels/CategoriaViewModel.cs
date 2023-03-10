using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(1, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        public string? Nome { get; set; }

        public string? Slug { get; set; }

        public string? AspNetUserId { get; set; }
        public IdentityUser? AspNetUser { get; set; }
    }
}
