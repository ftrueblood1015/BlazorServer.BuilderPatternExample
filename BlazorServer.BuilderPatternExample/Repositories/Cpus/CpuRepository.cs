using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Infrastructure;

namespace BlazorServer.BuilderPatternExample.Repositories.Cpus
{
    public class CpuRepository : RepositoryBase<Cpu, BuilderPatternExampleContext>, ICpuRepository
    {
        public CpuRepository(BuilderPatternExampleContext context) : base(context)
        {
        }
    }
}
