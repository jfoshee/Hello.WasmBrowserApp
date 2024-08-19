using System.Runtime.InteropServices.JavaScript;

namespace Hello.WasmBrowserApp;

public partial class Canvas
{
    [JSImport("canvas.drawLine", "main.js")]
    internal static partial void DrawLine(float x1,
                                          float y1,
                                          float x2,
                                          float y2,
                                          float r,
                                          float g,
                                          float b);
}
