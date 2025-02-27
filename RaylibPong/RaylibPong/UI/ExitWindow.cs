using Raylib_cs;

namespace RaylibPong.UI;

internal class ExitWindow
{
    public static void Draw(int width)
    {
        Raylib.DrawRectangle(0, 100, width, 200, Color.Black);
        Raylib.DrawText("Do you really want to exit?", 40, 180, 30, Color.White);
        Raylib.DrawText("Press Y to confirm or N to cancel", 120, 200, 20, Color.LightGray);
    }
}