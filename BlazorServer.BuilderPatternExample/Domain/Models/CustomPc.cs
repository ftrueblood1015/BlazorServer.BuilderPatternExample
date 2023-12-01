using System.ComponentModel.DataAnnotations;

namespace BlazorServer.BuilderPatternExample.Domain.Models
{
    public class CustomPc : BaseModel
    {
        [Required]
        public int? TotalCost { get; set; }

        [Required]
        public string? CustomerName {  get; set; }

        [Required]
        public int? CpuId { get; set; }
        
        public Cpu? Cpu { get; set; }

        [Required]
        public int? GpuId { get; set; }

        public Gpu? Gpu { get; set;}

        [Required]
        public int? HardDriveId { get; set; }

        public HardDrive? HardDrive { get; set;}

        [Required]
        public int? RamId { get; set; }

        public Ram? Ram { get; set; }

        [Required]
        public int? PcLevelId { get; set; }

        public PcLevel? PcLevel { get; set; }
    }
}
