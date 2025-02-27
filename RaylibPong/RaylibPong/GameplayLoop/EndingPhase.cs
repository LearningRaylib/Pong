using Raylib_cs;

namespace RaylibPong.GameplayLoop;

internal class EndingPhase : IGamePhase
{
    private Settings settings;

    public EndingPhase(Settings settings)
    {
        this.settings = settings;
    }

    public void Draw()
    {
        Raylib.DrawRectangle(0, 0, settings.Width, settings.Height, Color.Blue);
        Raylib.DrawText("ENDING SCREEN", 20, 20, 40, Color.DarkBlue);
        Raylib.DrawText("PRESS ENTER to JUMP to TITLE SCREEN", 290, 220, 20, Color.DarkBlue);
    }

    public void Unload()
    {
    }

    public void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            Program.currentScreen = GameScreen.TITLE;
        }
    }
}
