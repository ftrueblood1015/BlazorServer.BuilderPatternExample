using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services.CustomPcs;
using BlazorServer.BuilderPatternExample.Services.PcLevels;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorServer.BuilderPatternExample.Pages
{
    public partial class OrderPc
    {
        [Inject]
        private NavigationManager? NavManager { get; set; }

        [Inject]
        private IPcLevelService? PcLevelService { get; set; }
        [Inject]
        private ICustomPcService? CustomPcService { get; set; }
        private List<PcLevel>? PcLevelList { get; set; }
        private CustomPc? NewPc { get; set; }
        bool success;
        string[] errors = { };
        MudForm? Form;

        protected override async Task OnInitializedAsync()
        {
            NewPc = new CustomPc();

            if (PcLevelService == null)
            {
                throw new ArgumentException(nameof(PcLevelService));
            }

            var PcLevelResponse = await PcLevelService.GetAllAsync();
            PcLevelList = PcLevelResponse != null ? PcLevelResponse.ToList() : new List<PcLevel>();
        }

        private void CancelClick()
        {
            if (NavManager != null)
            {
                NavManager.NavigateTo("/custompcs");
            }
        }

        private void PcLevelValueChange(int? id)
        {
            NewPc!.PcLevelId = id;
            NewPc!.PcLevel = PcLevelList?.Find(x => x.Id == NewPc.PcLevelId);
        }

        private void Save()
        {
            Form!.Validate();

            if (CustomPcService == null)
            {
                throw new ArgumentNullException(nameof(CustomPcService));
            }

            if (NewPc == null)
            {
                throw new ArgumentNullException(nameof(NewPc));
            }

            if (Form.IsValid)
            {
                try
                {
                    CustomPcService.Add(NewPc);
                    CancelClick();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
    }
}
