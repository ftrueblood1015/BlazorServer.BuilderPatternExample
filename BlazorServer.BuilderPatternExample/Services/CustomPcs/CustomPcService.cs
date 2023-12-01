using BlazorServer.BuilderPatternExample.Builders;
using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;
using BlazorServer.BuilderPatternExample.Repositories.CustomPcs;
using BlazorServer.BuilderPatternExample.Services.Cpus;
using BlazorServer.BuilderPatternExample.Services.Gpus;
using BlazorServer.BuilderPatternExample.Services.HardDrives;
using BlazorServer.BuilderPatternExample.Services.Rams;

namespace BlazorServer.BuilderPatternExample.Services.CustomPcs
{
    public class CustomPcService : ServiceBase<CustomPc, ICustomPcRepository>, ICustomPcService
    {
        private readonly ICpuService CpuService;
        private readonly IGpuService GpuService;
        private readonly IRamService RamService;
        private readonly IHardDriveService HardDriveService;
        public CustomPcService(IRepositoryBase<CustomPc> repo, ICpuService cpuService, IGpuService gpuServcie, IRamService ramService, IHardDriveService hardDriveService) : base(repo)
        {
            CpuService = cpuService;
            GpuService = gpuServcie;
            RamService = ramService;
            HardDriveService = hardDriveService;
        }

        public new CustomPc Add(CustomPc customPc)
        {
            ComputerStore computerStore = new ComputerStore(customPc.PcLevel!.Slug!, CpuService, GpuService, RamService, HardDriveService);

            var NewPcComponents = computerStore.Contruct();

            customPc.CpuId = NewPcComponents.Cpu!.Id;
            customPc.GpuId = NewPcComponents.Gpu!.Id;
            customPc.RamId = NewPcComponents.Ram!.Id;
            customPc.HardDriveId = NewPcComponents.HardDrive!.Id;

            customPc.TotalCost = NewPcComponents.Cpu!.Cost + NewPcComponents.Gpu!.Cost + NewPcComponents.Ram!.Cost + NewPcComponents.HardDrive!.Cost;
            customPc.Name = customPc.CustomerName;
            customPc.Slug = customPc.CustomerName;
            customPc.Description = $"{customPc.Name} {NewPcComponents.Cpu!.Description} {NewPcComponents.Gpu!.Description} " +
                $"{NewPcComponents.Ram!.Description} {NewPcComponents.HardDrive!.Description}";

            return Repo.Add(customPc);
        }
    }
}
