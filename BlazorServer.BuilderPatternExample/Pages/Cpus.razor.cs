using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.Cpus;
using BlazorServer.BuilderPatternExample.Services.PcLevels;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BuilderPatternExample.Pages
{
    public partial class Cpus
    {
        [Inject]
        private ICpuService? CpuService { get; set; }
        private List<Cpu>? CpuList { get; set; }
        private string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (CpuService == null)
            {
                throw new ArgumentException(nameof(CpuService));
            }

            var Response = await  CpuService.GetAllAsync();
            CpuList = Response != null ? Response.ToList() : new List<Cpu>();
        }

        private Func<Cpu, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Description!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Cores}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Cost}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
    }
}
