using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Repositories;
using BlazorServer.BuilderPatternExample.Repositories.Cpus;

namespace BlazorServer.BuilderPatternExample.Services.Cpus
{
    public class CpuService : ServiceBase<Cpu, ICpuRepository>, ICpuService
    {
        public CpuService(IRepositoryBase<Cpu> repo) : base(repo)
        {
        }
    }
}
