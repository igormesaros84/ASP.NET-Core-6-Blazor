using BethanysPieShopHRM.Shared.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BethanysPieShopHRM.ComponentsLibrary;

public partial class Map
{
    string elementId = $"map-{Guid.NewGuid():D}";

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Parameter]
    public double Zoom { get; set; }

    [Parameter]
    public List<Marker> Markers { get; set; }

    // It is important to run all Javascript interrop after all the html has been rendered
    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync(
            "deliveryMap.showOrUpdate",
            elementId, Markers);
    }
}
