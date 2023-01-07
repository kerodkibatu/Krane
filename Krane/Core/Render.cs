namespace Krane.Core;

public static class Render
{
    public static RenderWindow? Target;
    public static Vector2f ToWorldSpace(Vector2i screenSpace) => Target!.MapPixelToCoords(screenSpace);
    public static Vector2i ToScreenSpace(Vector2f worldSpace) => Target!.MapCoordsToPixel(worldSpace);
    public static void SetTarget(RenderWindow target) => Target = target;
    public static void Clear() => Target?.Clear();
    public static void Clear(Color c) => Target?.Clear(c);
    public static void Draw(Drawable drawable) => Target?.Draw(drawable);

}


