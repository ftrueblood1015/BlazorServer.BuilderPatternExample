using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.Cpus;
using BlazorServer.BuilderPatternExample.Services.Gpus;
using BlazorServer.BuilderPatternExample.Services.HardDrives;
using BlazorServer.BuilderPatternExample.Services.Rams;

namespace BlazorServer.BuilderPatternExample.Builders
{
    public class MidPcBuilder : PcBuilder
    {
        public new readonly ICpuService CpuService;
        public new readonly IGpuService GpuService;
        public new readonly IRamService RamService;
        public new readonly IHardDriveService HardDriveService;
        public MidPcBuilder(ICpuService cpuService, IGpuService gpuServcie, IRamService ramService, IHardDriveService hardDriveService)
            : base("MID", cpuService, gpuServcie, ramService, hardDriveService)
        {
            CpuService = cpuService;
            GpuService = gpuServcie;
            RamService = ramService;
            HardDriveService = hardDriveService;
        }

        public override void BuildCpu()
        {
            Cpu cpu = CpuService.GetBySlug(PcLevel)!;
            CustomPc!.Cpu = cpu;
            CustomPc!.CpuId = cpu.Id;
        }

        public override void BuildGpu()
        {
            Gpu gpu = GpuService.GetBySlug(PcLevel)!;
            CustomPc!.Gpu = gpu;
            CustomPc!.GpuId = gpu.Id;
        }

        public override void BuildHardDrive()
        {
            HardDrive hardDrive = HardDriveService.GetBySlug(PcLevel)!;
            CustomPc!.HardDrive = hardDrive;
            CustomPc!.HardDriveId = hardDrive.Id;
        }

        public override void BuildRam()
        {
            Ram ram = RamService.GetBySlug(PcLevel)!;
            CustomPc!.Ram = ram;
            CustomPc!.RamId = ram.Id;
        }
    }
}
