
namespace Krane.Core;

public static class Render
{
    public static RenderTarget? Target;
    public static void SetTarget(RenderTarget target)
    {
        Target = target;
    }
    public static void Clear()
    {
        Target?.Clear();
    }
    public static void Draw(Drawable drawable)
    {
        Target?.Draw(drawable);
    }

}


