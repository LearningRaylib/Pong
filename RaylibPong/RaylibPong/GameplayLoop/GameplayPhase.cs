using Raylib_cs;
using RaylibPong.GameLogic;
using RaylibPong.GameObjects;
using System.Numerics;

namespace RaylibPong.GameplayLoop;

internal class GameplayPhase : IGamePhase
{
    Ball theBall;
    Paddle player1Paddle;
    Paddle player2Paddle;

    Settings settings;
    bool IsPause = false;

    public GameplayPhase(Settings settings)
    {
        this.settings = settings;

        theBall = InitBall();
        player1Paddle = new Paddle(
            new Vector2(10, settings.VerticalCenter)
        );
        player2Paddle = new Paddle(
            new Vector2(settings.Screen.Width - 40, settings.VerticalCenter)
        );
    }

    private Ball InitBall() => new(
            settings.ScreenCenter,
            initialBallSpeed: new Vector2(-5.0f, -4.0f)
        );

    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);

        theBall.Draw();
        player1Paddle.Draw();
        player2Paddle.Draw();

        if (IsPause)
            Raylib.DrawText("paused", 350, 200, 30, Color.Gray);

        Raylib.DrawFPS(10, 10);
    }

    public void Unload()
    {
    }

    public void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Space)) IsPause = !IsPause;

        if (!IsPause)
        {
            if (theBall.IsCollidingWithScreenBorderX())
            {
                // todo: point scored
                theBall = InitBall();
            }
            if (theBall.IsCollidingWithScreenBorderY())
                theBall.InvertVerticalDirection();

            if (theBall.IsCollidingWith(player1Paddle) || 
                theBall.IsCollidingWith(player2Paddle))
                theBall.InvertHorizontalDirection();

            if (Raylib.IsKeyDown(KeyboardKey.W)) player1Paddle.MoveVertically(-5.0f);
            if (Raylib.IsKeyDown(KeyboardKey.S)) player1Paddle.MoveVertically(5.0f);
            if (Raylib.IsKeyDown(KeyboardKey.Up)) player2Paddle.MoveVertically(-5.0f);
            if (Raylib.IsKeyDown(KeyboardKey.Down)) player2Paddle.MoveVertically(5.0f);

            theBall.Update();
        }
    }
}
