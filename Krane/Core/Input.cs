using static SFML.Window.Keyboard;
using static SFML.Window.Mouse;
namespace Krane.Core;
public static class Input
{
    static Dictionary<Button, bool> wasButtonDown = new();
    static Dictionary<Key, bool> wasKeyDown = new();

    public static int DScroll { get; private set; }
    public static Vector2f DMouse { get; private set; }
    public static Vector2f MousePos { get; private set; }
    static Input()
    {
        EachButton(btn => wasButtonDown.Add(btn, false));
        EachKey(key => wasKeyDown.Add(key, false));
        var Window = Render.Target!;
        Window.MouseWheelScrolled += (_, e) => DScroll = (int)e.Delta;
        Window.MouseMoved += (_, e) => DMouse = (Render.ToWorldSpace(new Vector2i(e.X, e.Y)) - MousePos) / GameTime.DeltaTime.AsSeconds();
    }

    public static bool IsMouseDown(Button button)
    {
        return IsButtonPressed(button);
    }
    public static bool WasMouseDown(Button button)
    {
        return wasButtonDown[button];
    }
    public static bool IsKeyDown(Key key)
    {
        return IsKeyPressed(key);
    }
    public static bool WasKeyDown(Key key)
    {
        return wasKeyDown[key];
    }

    public static void Update()
    {
        MousePos = Render.ToWorldSpace(GetPosition(Render.Target));
        EachButton(btn =>
        {
            if (IsMouseDown(btn) && !wasButtonDown[btn])
            {
                wasButtonDown[btn] = true;
            }
            else if (!IsMouseDown(Button.Left))
            {
                wasButtonDown[btn] = false;
            }
        });
        EachKey(key =>
        {
            if (IsKeyDown(key) && !wasKeyDown[key])
            {
                wasKeyDown[key] = true;
            }
            else if (!IsKeyDown(key))
            {
                wasKeyDown[key] = false;
            }
        });
    }
    public static void ResetDeltas()
    {
        DScroll = 0;
        DMouse *= 0;
    }
    static void EachButton(Action<Button> action)
    {
        foreach (Button btn in Enum.GetValues<Button>().Distinct())
        {
            action(btn);
        }
    }
    static void EachKey(Action<Key> action)
    {
        foreach (Key key in Enum.GetValues<Key>().Distinct())
        {
            action(key);
        }
    }
}
