using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;
using BlazorServer.BuilderPatternExample.Repositories.Gpus;

namespace BlazorServer.BuilderPatternExample.Services.Gpus
{
    public class GpuService : ServiceBase<Gpu, IGpuRepository>, IGpuService
    {
        public GpuService(IRepositoryBase<Gpu> repo) : base(repo)
        {
        }
    }
}
