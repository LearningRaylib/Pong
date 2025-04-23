using Raylib_cs;

namespace RaylibPong.GameplayLoop;

internal class TitlePhase : IGamePhase
{
    private const int FontSize = 20;
    private const int MenuOptionX = 220;

    private readonly Settings settings;

    public TitlePhase(Settings settings)
    {
        this.settings = settings;
    }

    public void Draw()
    {
        Raylib.ClearBackground(Color.RayWhite);

        Raylib.DrawText("RayPong!", 20, 20, FontSize + 20, Color.DarkGreen);

        int menuOptionY = 50;
        if (Program.IsPaused)
        {
            Raylib.DrawText("(R)esume", MenuOptionX, menuOptionY, FontSize, Color.DarkGreen);
        }
        menuOptionY += 30;
        Raylib.DrawText("(N)ew Game", MenuOptionX, menuOptionY, FontSize, Color.DarkGreen);
        menuOptionY += 30;
        Raylib.DrawText("(O)ptions", MenuOptionX, menuOptionY, FontSize, Color.DarkGreen);
        menuOptionY += 30;
        Raylib.DrawText("(Q)uit", MenuOptionX, menuOptionY, FontSize, Color.DarkGreen);

    }

    public void Unload()
    {
    }

    public void Update()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.R) || Raylib.IsKeyPressed(KeyboardKey.Escape))
        {
            Program.IsPaused = false;
            Program.CurrentScreen = GameScreen.GAMEPLAY;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.N))
        {
            Program.NewGame();
            Program.IsPaused = false;
            Program.CurrentScreen = GameScreen.GAMEPLAY;
        }
        else if (Raylib.IsKeyPressed(KeyboardKey.Q))
        {
            Program.CurrentScreen = GameScreen.ENDING;
        }
    }
}
