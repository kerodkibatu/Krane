using Krane.Core;
using static SFML.Window.Keyboard;
using static SFML.Window.Mouse;

namespace Krane.Interactive;
public static class Input
{
    static Dictionary<Button, bool> wasButtonDown = new();
    static Dictionary<Key, bool> wasKeyDown = new();

    public static int scrollDelta { get; private set; }
    public static Vector2f deltaMouse { get; private set; }
    public static Vector2f mousePosition { get; private set; }
    static Input()
    {
        EachButton(btn => wasButtonDown.Add(btn, false));
        EachKey(key => wasKeyDown.Add(key, false));
        var Window = Render.Target!;
        Window.MouseWheelScrolled += (_, e) => scrollDelta = (int)e.Delta;
        Window.MouseMoved += (_, e) => deltaMouse = (Render.ToWorldSpace(new Vector2i(e.X, e.Y))-mousePosition) / GameTime.deltaTime.AsSeconds();
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
        mousePosition = Render.ToWorldSpace(GetPosition(Render.Target));
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
        scrollDelta = 0;
        deltaMouse *= 0;
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
