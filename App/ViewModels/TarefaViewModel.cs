using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.ViewModels
{
    public class TarefaViewModel
    {
        public class Tarefa
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório.")]
            [StringLength(255, ErrorMessage = "O campo {0} não pode ter menos do que {2} e mais do que {1} caracteres.", MinimumLength = 3)]
            [DisplayName("Conteúdo")]
            public string? Conteudo { get; set; }

            [DisplayName("Concluído")]
            public bool Concluido { get; set; }

            public string? AspNetUserId { get; set; }
            public IdentityUser? AspNetUser { get; set; }
        }
    }
}
