using Krane.Core;

namespace Krane.Interactive;
public static class Input
{
	public static Vector2f GetMousePosition()
	{
		return Render.Target!.MapPixelToCoords(Mouse.GetPosition((Window?)Render.Target));
	}
	public static bool IsButtonPressed(Mouse.Button button)
	{
		return Mouse.IsButtonPressed(button);
	}
	public static bool IsKeyPressed(Keyboard.Key key)
	{
		return Keyboard.IsKeyPressed(key);
	}
}
