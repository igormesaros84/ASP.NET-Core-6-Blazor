using Microsoft.AspNetCore.Components;

namespace BethanyPieShopHRM.Components;

public partial class ProfilePicture
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
