using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;
using BlazorServer.BuilderPatternExample.Repositories.Rams;

namespace BlazorServer.BuilderPatternExample.Services.Rams
{
    public class RamService : ServiceBase<Ram, IRamRepository>, IRamService
    {
        public RamService(IRepositoryBase<Ram> repo) : base(repo)
        {
        }
    }
}
