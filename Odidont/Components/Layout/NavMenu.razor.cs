using Microsoft.AspNetCore.Components;

namespace Odidont.Components.Layout;

public class PageDef
{
    public required string Name { get; init; }
    public required string Href { get; init; }
    public string Icon { get; init; } = "bi-ban";
}

public partial class NavMenu : ComponentBase
{
    public List<PageDef> pages = 
    [
        new()
        {
            Name="Home",
            Href="",
            Icon="bi-house-door-fill",
        },
        new()
        {
            Name="Learn",
            Href="learn",
            Icon="bi-mortarboard-fill",
        },
        new()
        {
            Name="GDPR Check",
            Href="check",
            Icon="bi-shield-fill-check",
        }
    ];
}