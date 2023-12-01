using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;
using BlazorServer.BuilderPatternExample.Repositories.PcLevels;

namespace BlazorServer.BuilderPatternExample.Services.PcLevels
{
    public class PcLevelService : ServiceBase<PcLevel, IPcLevelRepository>, IPcLevelService
    {
        public PcLevelService(IRepositoryBase<PcLevel> repo) : base(repo)
        {
        }
    }
}
