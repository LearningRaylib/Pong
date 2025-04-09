using Raylib_cs;
using RaylibPong.GameplayLoop;

namespace RaylibPong;

enum GameScreen { LOGO, TITLE, GAMEPLAY, ENDING };

internal class Program
{
    public static GameScreen currentScreen { get; set; } = GameScreen.LOGO;
    public static Settings settings = new();

    private static IGamePhase? logoPhase;
    private static IGamePhase? gameplayPhase;
    private static IGamePhase? titlePhase;
    private static IGamePhase? endingPhase;

    public static bool exitWindow = false;

    private static IGamePhase GetGamePhase(GameScreen currentScreen)
    {
        return currentScreen switch
        {
            GameScreen.TITLE => titlePhase == null ? titlePhase = new TitlePhase(settings) : titlePhase,
            GameScreen.GAMEPLAY => gameplayPhase == null ? gameplayPhase = new GameplayPhase(settings) : gameplayPhase,
            GameScreen.ENDING => endingPhase == null ? endingPhase = new EndingPhase(settings) : endingPhase,
            _ => logoPhase == null ? logoPhase = new LogoPhase(settings) : logoPhase,
        };
    }

    public static void EndGame() 
        => exitWindow = true;

    static void Main(string[] args)
    {
        Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);

        Raylib.InitWindow(settings.Width, settings.Height, "Hello World");

        Raylib.SetExitKey(KeyboardKey.Null);
        Raylib.SetTargetFPS(settings.TargetFPS);

        IGamePhase currentGamePhase;

        // Main game loop
        while (!exitWindow)
        {
            currentGamePhase = GetGamePhase(currentScreen);

            currentGamePhase.Update();

            Raylib.BeginDrawing();

            currentGamePhase.Draw();

            Raylib.EndDrawing();
        }

        logoPhase?.Unload();
        titlePhase?.Unload();
        gameplayPhase?.Unload();
        endingPhase?.Unload();
        Raylib.CloseWindow();
    }
}
