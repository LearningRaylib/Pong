using Raylib_cs;
using RaylibPong.GameLogic;
using System.Numerics;

namespace RaylibPong.GameObjects;

public class Paddle 
{
    public Vector2 position { get; private set; }
    public Vector2 size = new Vector2(50, 100);

    public Paddle(Vector2 screenCenter)
    {
        position = screenCenter;
    }

    public void Draw()
        => position.DrawRectangle(size, Color.Black);

    public void MoveVertically(float v)
    {
        if (position.Y + v > 0 && position.Y + size.Y + v < Raylib.GetScreenHeight())
            position += new Vector2(0.0f, v);
    }

    public Rectangle ToRectangle()
        => new(position.X, position.Y, size.X, size.Y);
}
