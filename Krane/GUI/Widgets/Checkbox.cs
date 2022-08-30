using Krane.Interactive;
using System.Drawing;

namespace Krane.GUI.Widgets;
public class Checkbox : Widget
{
    public static uint DefaultSize = 32;
    public override bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    bool wasClicked = false;
    public override Vector2f Position => throw new NotImplementedException();
    public EventHandler? StateChanged { get; set; }
    public RectangleShape ToggleArea;
    Label label;
    public Checkbox()
    {

        ToggleArea = new();
    }

    public override void Update()
    {
        if (!Visible)
            return;
        var MousePos = Input.GetMousePosition();
        if (Rectangle.GetGlobalBounds().Contains(MousePos.X, MousePos.Y) && Input.isMousePressed(Mouse.Button.Left) && !wasClicked)
        {
            StateChanged?.Invoke(this, new());
            wasClicked = true;
        }
        else if (!Input.isMousePressed(Mouse.Button.Left))
        {
            wasClicked = false;
        }
    }
    public override void Draw()
    {

    }

}
