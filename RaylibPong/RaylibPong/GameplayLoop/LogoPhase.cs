using RaylibPong.Graphics;

namespace RaylibPong.GameplayLoop;

internal class LogoPhase : IGamePhase
{
    private int frameCounter = 0;
    private Settings settings;

    public LogoPhase(Settings settings)
    {
        this.settings = settings;
    }

    public void Update()
    {
        frameCounter++;
        if (frameCounter > 120)
        {
            Program.currentScreen = GameScreen.TITLE;
        }
    }

    public void Draw()
    {
        RaylibLogoRenderer.DrawLogo(settings.Width, settings.Height);
    }

    public void Unload()
    {
    }
}
