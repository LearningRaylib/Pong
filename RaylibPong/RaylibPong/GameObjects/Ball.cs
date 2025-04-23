using Raylib_cs;
using RaylibPong.GameLogic;
using System.Numerics;

namespace RaylibPong.GameObjects;

public interface ICollideLikeACircle
{
    Vector2 Position { get; }
    int Radius { get; }
}

public class Ball : ICollideLikeACircle
{
    public Vector2 Position { get; private set; }

    public int Radius => 20;

    Vector2 speed;

    public Ball(Vector2 screenCenter, Vector2 initialBallSpeed)
    {
        Position = screenCenter;
        speed = initialBallSpeed;
    }

    public void Draw()
        => Position.DrawCircle(Radius, Color.Maroon);

    public void MoveHorizontally(float newH)
        => Position = Position + new Vector2(newH, 0.0f);

    public void MoveVertically(float newY)
        => Position = Position + new Vector2(0.0f, newY);

    public void InvertHorizontalDirection()
        => speed.X *= -1.0f;

    public void InvertVerticalDirection()
        => speed.Y *= -1.0f;

    internal void Update()
    {
        Position = Position + speed;
    }
}
