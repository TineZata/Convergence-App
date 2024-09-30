using ConvergenceComponents.Components.Font;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvergenceComponents
{
    public class WidgetBase : ComponentBase
    {
        [Parameter]
        public string Class { get; set; } = "";

        [Parameter]
        public bool IsVisible { get; set; } = true;

        [Parameter]
        public int Width { get; set; }

        [Parameter]
        public int Height { get; set; }

        [Parameter]
        public string TooltipText { get; set; } = string.Empty;
        [Parameter]
        public bool ShowTooltip { get; set; } = false;
    }
}
