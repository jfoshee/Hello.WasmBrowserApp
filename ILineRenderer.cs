using System.Numerics;

namespace Hello.WasmBrowserApp;

public interface ILineRenderer
{
    void DrawLine(Vector2 start, Vector2 end);
}
