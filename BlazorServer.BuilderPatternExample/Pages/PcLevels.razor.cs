using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.PcLevels;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BuilderPatternExample.Pages
{
    public partial class PcLevels
    {
        [Inject]
        private IPcLevelService? PcLevelService { get; set; }
        private List<PcLevel>? PcLevelList { get; set; }
        private string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (PcLevelService == null)
            {
                throw new ArgumentException(nameof(PcLevelService));
            }

            var Response = await PcLevelService.GetAllAsync();
            PcLevelList = Response != null ? Response.ToList() : new List<PcLevel>();
        }

        private Func<PcLevel, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Name!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Description!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
    }
}
