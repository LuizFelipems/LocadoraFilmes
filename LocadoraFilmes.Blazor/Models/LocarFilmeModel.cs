using System.ComponentModel.DataAnnotations;

namespace LocadoraFilmes.Blazor.Models
{
    public class LocarFilmeModel
    {
        [Required]
        public string CpfCliente { get; set; }
        [Required]
        public DateTime DataLocacao { get; set; }
        [Required]
        public List<Guid> FilmeIds { get; set; }
    }
}
