using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;
using BlazorServer.BuilderPatternExample.Repositories.HardDrives;

namespace BlazorServer.BuilderPatternExample.Services.HardDrives
{
    public class HardDriveService : ServiceBase<HardDrive, IHardDriveRepository>, IHardDriveService
    {
        public HardDriveService(IRepositoryBase<HardDrive> repo) : base(repo)
        {
        }
    }
}
