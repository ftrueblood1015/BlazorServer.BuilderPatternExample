using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.Gpus;
using BlazorServer.BuilderPatternExample.Services.PcLevels;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BuilderPatternExample.Pages
{
    public partial class Gpus
    {
        [Inject]
        private IGpuService? GpuService { get; set; }
        private List<Gpu>? GpuList { get; set; }
        private string? SearchString {  get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (GpuService == null)
            {
                throw new ArgumentException(nameof(GpuService));
            }

            var Response = await GpuService.GetAllAsync();
            GpuList = Response != null ? Response.ToList() : new List<Gpu>();
        }

        private Func<Gpu, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Description!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Cost!}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
    }
}
