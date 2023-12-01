using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Infrastructure;

namespace BlazorServer.BuilderPatternExample.Repositories.Gpus
{
    public class GpuRepository : RepositoryBase<Gpu, BuilderPatternExampleContext>, IGpuRepository
    {
        public GpuRepository(BuilderPatternExampleContext context) : base(context)
        {
        }
    }
}
