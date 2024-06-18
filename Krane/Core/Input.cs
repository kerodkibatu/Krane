using static SFML.Window.Keyboard;
using static SFML.Window.Mouse;
namespace Krane.Core;
public static class Input
{
    private static Dictionary<Button, bool> wasButtonDown = new();
    private static Dictionary<Key, bool> wasKeyDown = new();

    public static int DScroll { get; private set; }
    public static Vector2f DMouse { get; private set; }
    public static Vector2f MousePos { get; private set; }

    static Input()
    {
        InitializeButtonStates();
        InitializeKeyStates();
        var Window = Render.Target!;
        Window.MouseWheelScrolled += (_, e) => DScroll = (int)e.Delta;
        Window.MouseMoved += (_, e) => DMouse = (new Vector2f(e.X, e.Y) - MousePos) / GameTime.DeltaTime.AsSeconds();
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
        UpdateMousePosition();
        UpdateButtonStates();
        UpdateKeyStates();
    }

    public static void ResetDeltas()
    {
        DScroll = 0;
        DMouse *= 0;
    }

    private static void InitializeButtonStates()
    {
        EachButton(btn => wasButtonDown.Add(btn, false));
    }

    private static void InitializeKeyStates()
    {
        EachKey(key => wasKeyDown.Add(key, false));
    }

    private static void UpdateMousePosition()
    {
        MousePos = Render.ToWorldSpace(GetPosition(Render.Target));
    }

    private static void UpdateButtonStates()
    {
        EachButton(btn =>
        {
            if (IsMouseDown(btn) && !wasButtonDown[btn])
            {
                wasButtonDown[btn] = true;
            }
            else if (!IsMouseDown(btn) && wasButtonDown[btn])
            {
                wasButtonDown[btn] = false;
            }
        });
    }

    private static void UpdateKeyStates()
    {
        EachKey(key =>
        {
            if (IsKeyDown(key) && !wasKeyDown[key])
            {
                wasKeyDown[key] = true;
            }
            else if (!IsKeyDown(key) && wasKeyDown[key])
            {
                wasKeyDown[key] = false;
            }
        });
    }

    private static void EachButton(Action<Button> action)
    {
        foreach (Button btn in Enum.GetValues<Button>().Distinct())
        {
            action(btn);
        }
    }

    private static void EachKey(Action<Key> action)
    {
        foreach (Key key in Enum.GetValues<Key>().Distinct())
        {
            action(key);
        }
    }
}
