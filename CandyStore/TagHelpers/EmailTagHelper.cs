using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CandyStore.TagHelpers;

public class EmailTagHelper : TagHelper
{
    public string Address { get; set; } = default!;
    public string LinkText { get; set; } = default!;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        output.TagName = "a";
        output.Attributes.SetAttribute("href", "mailto" + Address);
        output.Content.SetContent(LinkText);
    }
}