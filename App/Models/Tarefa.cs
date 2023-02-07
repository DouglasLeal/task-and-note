using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres.")]
        [MaxLength(255, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
        [DisplayName("Conteúdo")]
        public string? Conteudo { get; set; }

        [DisplayName("Concluído")]
        public bool Concluido { get; set; }

        [Required]
        public string? AspNetUserId { get; set; }
        public IdentityUser? AspNetUser { get; set; }
    }
}
