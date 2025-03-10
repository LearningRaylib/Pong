﻿using Raylib_cs;
using RaylibPong.GameLogic;
using RaylibPong.GameObjects;
using System.Numerics;

namespace RaylibPong.GameplayLoop;

internal class GameplayPhase : IGamePhase
{
    Ball theBall;
    Paddle playerPaddle;

    Settings settings;
    bool IsPause = false;

    public GameplayPhase(Settings settings)
    {
        this.settings = settings;

        theBall = new Ball(
            settings.ScreenCenter,
            initialBallSpeed: new Vector2(5.0f, 4.0f)
        );
        playerPaddle = new Paddle(
            new Vector2(10, settings.VerticalCenter)
        );
    }

    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);

        theBall.Draw();
        playerPaddle.Draw();

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
            if (theBall.IsCollidingWithScreenBorderX()) theBall.InvertHorizontalDirection();
            if (theBall.IsCollidingWithScreenBorderY()) theBall.InvertVerticalDirection();

            if (Raylib.IsKeyDown(KeyboardKey.W)) playerPaddle.MoveVertically(-5.0f);
            if (Raylib.IsKeyDown(KeyboardKey.S)) playerPaddle.MoveVertically(5.0f);

            theBall.Update();
        }
    }
}
