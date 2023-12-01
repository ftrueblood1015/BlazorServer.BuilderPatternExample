using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BuilderPatternExample.Domain.Models
{
    public class Ram : BaseCostModel
    {
        [Required]
        public string? Type { get; set; }

        [Required]
        public int? RamAmount { get; set; }
    }
}
