namespace Krane.Core;
public static class GameTime
{
    private static Clock gameTime = new();
    public static Time DeltaTime;
    public static Time TotalTime = new();
    public static ulong Ticks = 0;
    public static float FPS => 1 / DeltaTime.AsSeconds();
    public static void Tick()
    {
        DeltaTime = gameTime.Restart();
        TotalTime += DeltaTime;
        Ticks++;
    }
}


