using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.CustomPcs;
using BlazorServer.BuilderPatternExample.Services.PcLevels;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.BuilderPatternExample.Pages
{
    public partial class CustomPcs
    {
        [Inject]
        private NavigationManager? NavManager { get; set; }
        [Inject]
        private ICustomPcService? CustomPcService { get; set; }
        private List<CustomPc>? CustomPcList { get; set; }
        private string? SearchString { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (CustomPcService == null)
            {
                throw new ArgumentException(nameof(PcLevelService));
            }

            var Response = CustomPcService.GetAll();
            CustomPcList = Response != null ? Response.ToList() : new List<CustomPc>();
        }

        private Func<CustomPc, bool> QuickFilter => x =>
        {
            if (string.IsNullOrWhiteSpace(SearchString))
                return true;

            if (x.CustomerName!.Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if ($"{x.TotalCost}".Contains(SearchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        };

        void CreateNewPc() 
        { 
            if (NavManager != null)
            {
                NavManager.NavigateTo("/orderpc");
            }
        }
    }
}
