using Raylib_cs;
using RaylibPong.GameObjects;

namespace RaylibPong.GameLogic;

public enum ScreenBorder
{
    Top,
    Bottom,
    Left,
    Right
}

public static class CollisionDetection
{
    public static (bool, ScreenBorder) IsCollidingWithScreenBorderX(this IAmA2dBeing being)
    {
        if (being.Position.X >= Raylib.GetScreenWidth() - being.Radius)
            return (true, ScreenBorder.Right);

        if (being.Position.X <= being.Radius)
            return (true, ScreenBorder.Left);

        return (false, ScreenBorder.Left);

    }

    //public static bool IsCollidingWithScreenBorderX(this IAmA2dBeing being)
    //    => being.Position.X >= Raylib.GetScreenWidth() - being.Radius || being.Position.X <= being.Radius;

    public static bool IsCollidingWithScreenBorderY(this IAmA2dBeing being)
        => being.Position.Y >= Raylib.GetScreenHeight() - being.Radius || being.Position.Y <= being.Radius;

    public static bool IsCollidingWith(this ICollideLikeACircle theBall, ICollideLikeARectangle paddle)
        => Raylib.CheckCollisionCircleRec(theBall.Position, theBall.Radius, paddle.ToRectangle());
}
