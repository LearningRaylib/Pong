namespace RaylibPong.GameplayLoop
{
    internal interface IGamePhase
    {
        void Update();
        void Draw();
        void Unload();
    }
}
