using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BuilderPatternExample.Domain.Models
{
    public class BaseCostModel : BaseModel
    {
        [Required]
        public int? Cost { get; set; }
    }
}
