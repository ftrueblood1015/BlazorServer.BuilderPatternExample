using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BuilderPatternExample.Domain.Models
{
    public class Cpu : BaseCostModel
    {
        [Required]
        public string? BaseSpeed { get; set; }

        [Required]
        public int? Cores { get; set; }
    }
}
