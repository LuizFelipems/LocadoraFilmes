using System.ComponentModel.DataAnnotations;

namespace LocadoraFilmes.Blazor.Models
{
    public class CreateFilmeModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public Guid GeneroId { get; set; }
    }
}
