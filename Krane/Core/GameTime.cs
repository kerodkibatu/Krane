namespace Krane.Core;
public static class GameTime
{
    private static Clock gameTime = new Clock();
    public static Time DeltaTime { get; private set; }
    public static Time TotalTime { get; private set; } = new Time();
    public static ulong Ticks { get; private set; } = 0;
    public static float FPS => 1 / DeltaTime.AsSeconds();

    public static void Tick()
    {
        DeltaTime = gameTime.Restart();
        TotalTime += DeltaTime;
        Ticks++;
    }
}


