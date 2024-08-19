using System;
using System.Runtime.InteropServices.JavaScript;

namespace Hello.WasmBrowserApp;

public partial class MyClass
{
    [JSExport]
    internal static string Greeting()
    {
        var text = $"Hello, World! Greetings from {GetHRef()}";
        Console.WriteLine(text);
        return text;
    }

    [JSImport("window.location.href", "main.js")]
    internal static partial string GetHRef();
}

public partial class Canvas
{
    [JSImport("canvas.drawLine", "main.js")]
    internal static partial void DrawLine(float x1, float y1, float x2, float y2);
}

public class CanvasLineRenderer : ILineRenderer
{
    public void DrawLine(System.Numerics.Vector2 start, System.Numerics.Vector2 end)
    {
        Canvas.DrawLine(start.X, start.Y, end.X, end.Y);
    }
}
