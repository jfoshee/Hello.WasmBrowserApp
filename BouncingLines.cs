using System;
using System.Numerics;

namespace Hello.WasmBrowserApp;

public class BouncingLines
{
    private readonly ILineRenderer _lineRenderer;
    private readonly Vector2[] _positions;
    private readonly Vector2[] _velocities;
    private readonly Vector2 _bounds;

    public BouncingLines(ILineRenderer lineRenderer, int lineCount, Vector2 bounds)
    {
        _lineRenderer = lineRenderer;
        _positions = new Vector2[lineCount * 2];
        _velocities = new Vector2[lineCount];
        _bounds = bounds;

        var random = new Random();
        for (int i = 0; i < lineCount; i++)
        {
            _positions[i * 2] = new Vector2(
                (float)(random.NextDouble() * bounds.X),
                (float)(random.NextDouble() * bounds.Y));

            _positions[i * 2 + 1] = new Vector2(
                (float)(random.NextDouble() * bounds.X),
                (float)(random.NextDouble() * bounds.Y));

            _velocities[i] = new Vector2(
                (float)(random.NextDouble() * 400 - 1),
                (float)(random.NextDouble() * 400 - 1));
        }
    }

    public void Update(TimeSpan elapsedTime)
    {
        float elapsedSeconds = (float)elapsedTime.TotalSeconds;

        for (int i = 0; i < _velocities.Length; i++)
        {
            _positions[i * 2] += _velocities[i] * elapsedSeconds;
            _positions[i * 2 + 1] += _velocities[i] * elapsedSeconds;

            for (int j = 0; j < 2; j++)
            {
                if (_positions[i * 2 + j].X < 0 || _positions[i * 2 + j].X > _bounds.X)
                    _velocities[i].X *= -1;

                if (_positions[i * 2 + j].Y < 0 || _positions[i * 2 + j].Y > _bounds.Y)
                    _velocities[i].Y *= -1;
            }
        }
    }

    public void Render()
    {
        for (int i = 0; i < _velocities.Length; i++)
        {
            _lineRenderer.DrawLine(_positions[i * 2], _positions[i * 2 + 1]);
        }
    }
}
