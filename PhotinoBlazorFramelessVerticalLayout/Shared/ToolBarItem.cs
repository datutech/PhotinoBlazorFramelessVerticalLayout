using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotinoBlazorFramelessVerticalLayout.Shared
{
    public class ToolBarItem
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public bool Visible { get; set; } = true;
        public Action? OnClicked { get; set; }
    }
}
