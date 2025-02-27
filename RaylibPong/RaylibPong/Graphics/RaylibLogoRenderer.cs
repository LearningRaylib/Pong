using Raylib_cs;

namespace RaylibPong.Graphics;

internal class RaylibLogoRenderer
{
    public static void DrawLogo(int width, int height)
    {
        Raylib.ClearBackground(Color.RayWhite);

        Raylib.DrawRectangle(width / 2 - 128, height / 2 - 128, 256, 256, Color.Black);
        Raylib.DrawRectangle(width / 2 - 112, height / 2 - 112, 224, 224, Color.RayWhite);
        Raylib.DrawText("raylib", width / 2 - 44, height / 2 + 48, 50, Color.Black);
    }
}