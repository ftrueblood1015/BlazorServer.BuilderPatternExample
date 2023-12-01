using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Infrastructure;

namespace BlazorServer.BuilderPatternExample.Repositories.HardDrives
{
    public class HardDriveRepository : RepositoryBase<HardDrive, BuilderPatternExampleContext>, IHardDriveRepository
    {
        public HardDriveRepository(BuilderPatternExampleContext context) : base(context)
        {
        }
    }
}
