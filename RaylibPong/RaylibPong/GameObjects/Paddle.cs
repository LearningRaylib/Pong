using Raylib_cs;
using RaylibPong.GameLogic;
using System.Numerics;

namespace RaylibPong.GameObjects;

public interface ICollideLikeARectangle
{
    Rectangle ToRectangle();
}

public class Paddle : ICollideLikeARectangle
{
    public Vector2 Position { get; private set; }
    public Vector2 Size = new(20, 100);
    private float Speed = 5.0f;

    public Paddle(Vector2 screenCenter)
    {
        Position = screenCenter;
    }

    public void Draw()
        => Position.DrawRectangle(Size, Color.Black);

    public void MoveUp()
        => MoveVertically(-Speed);

    public void MoveDown()
        => MoveVertically(Speed);

    private void MoveVertically(float v)
    {
        if (Position.Y + v > 0 && Position.Y + Size.Y + v < Raylib.GetScreenHeight())
            Position += new Vector2(0.0f, v);
    }

    public Rectangle ToRectangle()
        => new(Position.X, Position.Y, Size.X, Size.Y);
}
