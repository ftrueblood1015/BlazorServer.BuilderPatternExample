using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Infrastructure;

namespace BlazorServer.BuilderPatternExample.Repositories.Rams
{
    public class RamRepository : RepositoryBase<Ram, BuilderPatternExampleContext>, IRamRepository
    {
        public RamRepository(BuilderPatternExampleContext context) : base(context)
        {
        }
    }
}
