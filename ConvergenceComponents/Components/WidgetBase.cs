using Convergence.IO.EPICS.CA;
using Convergence;
using ConvergenceComponents.Components.Font;
using ConvergenceComponents.Components.Styles;
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
		[Parameter]
		public string Name { get; set; } = string.Empty;
		[Parameter]
		public Protocols Protocol { get; set; } = Protocols.None;
		[Parameter]
		public Type DataType { get; set; } = typeof(string);
		[Parameter]
		public int ElementCount { get; set; } = 1;
		[Parameter]
		public bool IsDisabled { get; set; } = true;
		[Parameter]
		public BorderStatus BorderStatus { get; set; } = BorderStatus.NotConnected;

		protected SynchronizationContext? SyncContext { get; set; }
	}
}
