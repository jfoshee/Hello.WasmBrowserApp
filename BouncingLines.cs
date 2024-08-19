using System;
using System.Numerics;

namespace Hello.WasmBrowserApp;

public class BouncingLines
{
    private const float MaxSpeedComponent = 400f;

    private readonly ILineRenderer _lineRenderer;
    private readonly Vector2[] _positions;
    private readonly Vector2[] _velocities;
    private readonly Vector3[] _colors;
    private readonly Vector2 _bounds;

    public BouncingLines(ILineRenderer lineRenderer, int lineCount, Vector2 bounds)
    {
        _lineRenderer = lineRenderer;
        _positions = new Vector2[lineCount * 2];
        _velocities = new Vector2[lineCount * 2];
        _colors = new Vector3[lineCount];
        _bounds = bounds;

        var random = new Random();
        for (int i = 0; i < lineCount; i++)
        {
            // Initialize start point
            _positions[i * 2] = new Vector2(
                (float)(random.NextDouble() * bounds.X),
                (float)(random.NextDouble() * bounds.Y));

            // Initialize end point
            _positions[i * 2 + 1] = new Vector2(
                (float)(random.NextDouble() * bounds.X),
                (float)(random.NextDouble() * bounds.Y));

            // Initialize velocity for start point
            _velocities[i * 2] = new Vector2(
                (float)(random.NextDouble() * 2 - 1) * MaxSpeedComponent,
                (float)(random.NextDouble() * 2 - 1) * MaxSpeedComponent);

            // Initialize velocity for end point
            _velocities[i * 2 + 1] = new Vector2(
                (float)(random.NextDouble() * 2 - 1) * MaxSpeedComponent,
                (float)(random.NextDouble() * 2 - 1) * MaxSpeedComponent);

            // Initialize color for the line
            _colors[i] = new Vector3(
                (float)random.NextDouble(),
                (float)random.NextDouble(),
                (float)random.NextDouble());
        }
    }

    public void Update(TimeSpan elapsedTime)
    {
        float elapsedSeconds = (float)elapsedTime.TotalSeconds;

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] += _velocities[i] * elapsedSeconds;

            if (_positions[i].X < 0 || _positions[i].X > _bounds.X)
                _velocities[i].X *= -1;

            if (_positions[i].Y < 0 || _positions[i].Y > _bounds.Y)
                _velocities[i].Y *= -1;
        }
    }

    public void Render()
    {
        for (int i = 0; i < _colors.Length; i++)
        {
            _lineRenderer.DrawLine(_positions[i * 2], _positions[i * 2 + 1], _colors[i]);
        }
    }
}
