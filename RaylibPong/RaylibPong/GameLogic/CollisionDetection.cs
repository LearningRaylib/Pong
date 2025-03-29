using Raylib_cs;
using RaylibPong.GameObjects;

namespace RaylibPong.GameLogic;

public static class CollisionDetection
{
    public static bool IsCollidingWithScreenBorderX(this IAmA2dBeing being)
        => being.Position.X >= Raylib.GetScreenWidth() - being.Radius || being.Position.X <= being.Radius;

    public static bool IsCollidingWithScreenBorderY(this IAmA2dBeing being)
        => being.Position.Y >= Raylib.GetScreenHeight() - being.Radius || being.Position.Y <= being.Radius;

    public static bool IsCollidingWith(this ICollideLikeACircle theBall, ICollideLikeARectangle paddle)
        => Raylib.CheckCollisionCircleRec(theBall.Position, theBall.Radius, paddle.ToRectangle());
}
