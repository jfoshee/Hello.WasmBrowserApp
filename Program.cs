using System;
using System.Numerics;
using System.Threading.Tasks;
using Hello.WasmBrowserApp;

Console.WriteLine("Hello, Browser!");

var lineRenderer = new CanvasLineRenderer();
// lineRenderer.DrawLine(new Vector2(0, 0), new Vector2(100, 100), new Vector3(1, 0, 0));
var bouncingLines = new BouncingLines(lineRenderer, lineCount: 10, bounds: new Vector2(1000, 1000));

while (true)
{
    var dt = TimeSpan.FromSeconds(1.0 / 60.0);
    bouncingLines.Update(dt);
    bouncingLines.Render();
    // Yield back to the browser
    await Task.Delay(dt);
}
