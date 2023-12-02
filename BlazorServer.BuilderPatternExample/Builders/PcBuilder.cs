using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.Cpus;
using BlazorServer.BuilderPatternExample.Services.Gpus;
using BlazorServer.BuilderPatternExample.Services.HardDrives;
using BlazorServer.BuilderPatternExample.Services.Rams;

namespace BlazorServer.BuilderPatternExample.Builders
{
    public abstract class PcBuilder
    {
        public string PcLevel { get; set; }
        public CustomPc? CustomPc;
        public readonly ICpuService CpuService;
        public readonly IGpuService GpuService;
        public readonly IRamService RamService;
        public readonly IHardDriveService HardDriveService;

        public PcBuilder(string level, ICpuService cpuService, IGpuService gpuServcie, IRamService ramService, IHardDriveService hardDriveService) 
        {
            CustomPc = new CustomPc();
            PcLevel = level;
            CpuService = cpuService;
            GpuService = gpuServcie;
            RamService = ramService;
            HardDriveService = hardDriveService;
        }

        public abstract void BuildCpu();
        public abstract void BuildGpu();
        public abstract void BuildRam();
        public abstract void BuildHardDrive();
    }
}
