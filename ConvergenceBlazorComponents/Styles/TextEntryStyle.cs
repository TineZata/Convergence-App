using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvergenceBlazorComponents.Styles
{
    public struct TextEntryStyle
    {
        public static int DEFAULT_WIDTH = 128;
        public static int DEFAULT_HEIGHT = 32;
        public static Colour DEFAULT_BACKGROUND_COLOR = new Colour() { Red = 128, Green = 255, Blue = 255 };
        public static Colour DEFAULT_FOREGROUND_COLOR = Colour.SystemDrawingColorToColour(System.Drawing.Color.Black);
        public static Colour DEFAULT_BORDER_COLOR = Colour.SystemDrawingColorToColour(System.Drawing.Color.Gray);
        public static int DEFAULT_BORDER_WIDTH = 1;
    }
}
