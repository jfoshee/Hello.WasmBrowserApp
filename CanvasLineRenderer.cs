using System.Numerics;

namespace Hello.WasmBrowserApp;

public class CanvasLineRenderer : ILineRenderer
{
    public void DrawLine(Vector2 start, Vector2 end, Vector3 color)
    {
        Canvas.DrawLine(start.X,
                        start.Y,
                        end.X,
                        end.Y,
                        color.X,
                        color.Y,
                        color.Z);
    }
}
