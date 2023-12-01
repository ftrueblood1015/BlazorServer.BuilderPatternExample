using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Infrastructure;

namespace BlazorServer.BuilderPatternExample.Repositories.PcLevels
{
    public class PcLevelRepository : RepositoryBase<PcLevel, BuilderPatternExampleContext>, IPcLevelRepository
    {
        public PcLevelRepository(BuilderPatternExampleContext context) : base(context)
        {
        }
    }
}
