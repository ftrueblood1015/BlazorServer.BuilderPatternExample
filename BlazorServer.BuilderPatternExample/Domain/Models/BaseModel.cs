using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BuilderPatternExample.Domain.Models
{
    public class BaseModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Slug { get; set; }
    }
}
