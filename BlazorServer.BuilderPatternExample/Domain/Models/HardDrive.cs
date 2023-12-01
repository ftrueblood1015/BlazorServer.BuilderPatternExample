using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BuilderPatternExample.Domain.Models
{
    public class HardDrive : BaseCostModel
    {
        [Required]
        public string? Type { get; set; }

        [Required]
        public int? Size { get; set; }
    }
}
