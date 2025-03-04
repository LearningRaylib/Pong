using Raylib_cs;
using System.Numerics;

namespace RaylibPong.GameLogic;

internal static class DrawingExtensions
{
    public static void DrawCircle(this Vector2 position, int radius, Color color)
        => Raylib.DrawCircleV(position, radius, color);

    public static void DrawRectangle(this Vector2 position, Vector2 size, Color color)
        => Raylib.DrawRectangleV(position, size, color);


}
