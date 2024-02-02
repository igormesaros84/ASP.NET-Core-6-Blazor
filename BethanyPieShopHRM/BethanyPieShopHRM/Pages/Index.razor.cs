using BethanyPieShopHRM.Components.Widgets;

namespace BethanyPieShopHRM.Pages;

public partial class Index
{
    public List<Type> Widgets { get; set; } = new List<Type> { typeof(EmployeeCountWidget), typeof(InboxWidget) };
}
