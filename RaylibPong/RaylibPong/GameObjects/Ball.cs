using Raylib_cs;
using RaylibPong.GameLogic;
using System.Numerics;

namespace RaylibPong.GameObjects;

public interface IAmA2dBeing
{
    Vector2 position { get; }
    int radius { get; }
}

public class Ball : IAmA2dBeing
{
    public Vector2 position { get; private set; }

    public int radius => 20;

    Vector2 speed;

    public Ball(Vector2 screenCenter, Vector2 initialBallSpeed)
    {
        position = screenCenter;
        speed = initialBallSpeed;
    }

    public void Draw()
        => position.DrawCircle(radius, Color.Maroon);

    public void MoveHorizontally(float newH)
        => position = position + new Vector2(newH, 0.0f);

    public void MoveVertically(float newY)
        => position = position + new Vector2(0.0f, newY);

    public void InvertHorizontalDirection()
        => speed.X *= -1.0f;

    public void InvertVerticalDirection()
        => speed.Y *= -1.0f;

    internal void Update()
    {
        position = position + speed;
    }
}
