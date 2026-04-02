using Microsoft.AspNetCore.Components;
using Odidont.Models;

namespace Odidont.Components.Check;

public partial class CheckQuestionView : ComponentBase
{
    [Parameter] public required CheckQuestion Question { get; set; }

    [Parameter] public required EventCallback<CheckOption> OptionSelected { get; set; }

    private async Task SelectOption(CheckOption option)
    {
        await OptionSelected.InvokeAsync(option);
    }
}