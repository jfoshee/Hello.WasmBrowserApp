using System;
using System.Numerics;
using System.Threading.Tasks;
using Hello.WasmBrowserApp;

Console.WriteLine("Hello, Browser!");

var lineRenderer = new CanvasLineRenderer();
lineRenderer.DrawLine(new Vector2(0, 0), new Vector2(100, 100));
var bouncingLines = new BouncingLines(lineRenderer, lineCount: 10, bounds: new Vector2(500, 500));

while (true)
{
    bouncingLines.Update(TimeSpan.FromSeconds(1.0 / 60.0));
    bouncingLines.Render();
    await Task.Delay(16);
}
