using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.Rams;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BuilderPatternExample.Pages
{
    public partial class Rams
    {
        [Inject]
        private IRamService? RamService { get; set; }
        private List<Ram>? RamList { get; set; }    
        private string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (RamService == null)
            {
                throw new ArgumentException(nameof(RamService));
            }

            var Response = await RamService.GetAllAsync();
            RamList = Response != null ? Response.ToList() : new List<Ram>();
        }

        private Func<Ram, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Description!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Type!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Cost!}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.RamAmount!}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
    }
}
