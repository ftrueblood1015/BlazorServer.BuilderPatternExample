using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.BuilderPatternExample.Repositories.CustomPcs
{
    public class CustomPcRepository : RepositoryBase<CustomPc, BuilderPatternExampleContext>, ICustomPcRepository
    {
        public CustomPcRepository(BuilderPatternExampleContext context) : base(context)
        {
        }

        public new IEnumerable<CustomPc> GetAll()
        {
            var result = Context.Set<CustomPc>()
                .Include(c => c.Cpu)
                .Include(g => g.Gpu)
                .Include(h => h.HardDrive)
                .Include(r => r.Ram)
                .Include(l => l.PcLevel);
            return result;
        }
    }
}
