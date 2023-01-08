namespace Krane.Extensions;
public static class ShapeExtensions
{
    public static T CenterOrigin<T>(this T t) where T : Shape
    {
        var bounds = t.GetLocalBounds();
        t.Origin = new Vector2f(bounds.Height, bounds.Width) / 2f;
        return t;
    }
    public static T SetPosition<T>(this T t, Vector2f Position) where T : Shape
    {
        t.Position = Position;
        return t;
    }
    public static T SetPosition<T>(this T t, float X, float Y) where T : Shape => SetPosition(t,new Vector2f(X,Y));
}
