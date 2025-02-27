using System.Numerics;

namespace RaylibPong;

public class Settings
{
    public int Width { get; set; } = 800;
    public int Height { get; set; } = 450;
    public int TargetFPS { get; set; } = 60;

    public Vector2 ScreenCenter
        => new(Width / 2, Height / 2);

    public Screen Screen => new(Width, Height);
}

public record Screen(int Width, int Height);
