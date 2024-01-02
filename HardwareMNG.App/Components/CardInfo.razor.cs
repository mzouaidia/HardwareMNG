using Microsoft.AspNetCore.Components;

namespace HardwareMNG.App.Components;

public partial class CardInfo : ComponentBase
{
    [Parameter]
    public string Title { get; set; } = string.Empty;

    [Parameter]
    public int Count { get; set; }

    [Parameter]
    public string? TypeInfo { get; set; }

    public required string TypeColor = string.Empty;
    
    protected override void OnInitialized()
    {
        TypeColor = TypeInfo switch
        {
            "A" => "#0C3",
            "D" => "crimson",
            _ => "#4b4b4b"
        };
    }
}