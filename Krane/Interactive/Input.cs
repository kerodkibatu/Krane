namespace Krane.Interactive;
public static class Input
{
	static Window? Window;
	internal static void SetWindow(Window window)
	{
		Window = window;
	}
	public static Vector2i GetMousePosition()
	{
		return Mouse.GetPosition(Window);
	}
	public static bool isMousePressed(Mouse.Button button)
	{
		return Mouse.IsButtonPressed(button);
	}

}
