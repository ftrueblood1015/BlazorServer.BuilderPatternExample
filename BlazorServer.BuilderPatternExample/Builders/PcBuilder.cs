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

    public class BasePcBuilder : PcBuilder
    {
        public new readonly ICpuService CpuService;
        public new readonly IGpuService GpuService;
        public new readonly IRamService RamService;
        public new readonly IHardDriveService HardDriveService;
        public BasePcBuilder(ICpuService cpuService, IGpuService gpuServcie, IRamService ramService, IHardDriveService hardDriveService)
            : base("BASE", cpuService, gpuServcie, ramService, hardDriveService)
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

    public class TopPcBuilder : PcBuilder
    {
        public new readonly ICpuService CpuService;
        public new readonly IGpuService GpuService;
        public new readonly IRamService RamService;
        public new readonly IHardDriveService HardDriveService;
        public TopPcBuilder(ICpuService cpuService, IGpuService gpuServcie, IRamService ramService, IHardDriveService hardDriveService)
            : base("TOP", cpuService, gpuServcie, ramService, hardDriveService)
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
