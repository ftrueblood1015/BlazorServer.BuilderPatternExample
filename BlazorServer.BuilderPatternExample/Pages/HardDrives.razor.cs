using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.HardDrives;
using BlazorServer.BuilderPatternExample.Services.PcLevels;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BuilderPatternExample.Pages
{
    public partial class HardDrives
    {
        [Inject]
        private IHardDriveService? HardDriveService { get; set; }
        private List<HardDrive>? HardDriveList { get; set; }
        private string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (HardDriveService == null)
            {
                throw new ArgumentException(nameof(HardDriveService));
            }

            var Response = await HardDriveService.GetAllAsync();
            HardDriveList = Response != null ? Response.ToList() : new List<HardDrive>();
        }

        private Func<HardDrive, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.Description!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Cost!}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (x.Type!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.Size!}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };
    }
}
