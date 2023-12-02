using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.Cpus;
using BlazorServer.BuilderPatternExample.Services.Gpus;
using BlazorServer.BuilderPatternExample.Services.HardDrives;
using BlazorServer.BuilderPatternExample.Services.Rams;

namespace BlazorServer.BuilderPatternExample.Builders
{
    public class ComputerStore
    {
        private PcBuilder Builder;
        public readonly ICpuService CpuService;
        public readonly IGpuService GpuService;
        public readonly IRamService RamService;
        public readonly IHardDriveService HardDriveService;
        public ComputerStore(string level, ICpuService cpuService, IGpuService gpuServcie, IRamService ramService, IHardDriveService hardDriveService) 
        {
            CpuService = cpuService;
            GpuService = gpuServcie;
            RamService = ramService;
            HardDriveService = hardDriveService;

            switch (level)
            {
                case "BASE":
                    Builder = new BasePcBuilder(cpuService, gpuServcie, ramService, hardDriveService);
                    break;
                case "MID":
                    Builder = new MidPcBuilder(cpuService, gpuServcie, ramService, hardDriveService);
                    break;
                case "TOP":
                    Builder = new TopPcBuilder(cpuService, gpuServcie, ramService, hardDriveService);
                    break;
                default:
                    throw new Exception($"{level} is not supported.");
            }
        }

        public CustomPc Contruct()
        {
            Builder.BuildCpu();
            Builder.BuildGpu();
            Builder.BuildHardDrive();
            Builder.BuildRam();

            return Builder.CustomPc ?? new CustomPc();
        }
    }
}
