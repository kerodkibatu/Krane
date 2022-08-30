using Krane.Core;
using Krane.Resources;
using Krane.Interactive;

namespace Krane.GUI.Widgets;
public class Button : Widget
{
    public static Vector2f DefaultSize = new(150, 50);

    RectangleShape Rectangle;
    bool wasClicked = false;

    public Label Label;
    public override bool Visible { get; set; } = true;
    public override Vector2f Position => Rectangle.Position;
    public string DisplayedText => Label.DisplayedText;
    public EventHandler? Clicked { get; set; }
    public Color BackColor => Rectangle.FillColor;
    public Color ForeColor => Label.FillColor;
    public Button(string text, Vector2f Position, Vector2f? Size = null, Color? FillColor = null, Color? Outline = null,Color? TextColor = null)
    {
        Rectangle = new(Size ?? DefaultSize)
        {
            Position = Position,
            FillColor = FillColor ?? Color.White,
            OutlineColor = Outline ?? Color.Transparent,
            OutlineThickness = 1
        };
        Label = new(text, Rectangle.Position+Rectangle.Size/2f,true,FillColor:TextColor);
    }
    public void SetFillColor(Color Fill, Color? Outline = null)
    {
        Rectangle.FillColor = Fill;
        Rectangle.OutlineColor = Outline ?? Color.Transparent;
    }
    public void SetTextColor(Color Fill, Color? Outline = null)
    {
        Label.SetTextColor(Fill, Outline);
    }
    public override void Update()
    {
        if (!Visible)
            return;
        var MousePos = Input.GetMousePosition();
        if (Rectangle.GetGlobalBounds().Contains(MousePos.X, MousePos.Y) && Input.isMousePressed(Mouse.Button.Left) && !wasClicked)
        {
            Clicked?.Invoke(this, new());
            wasClicked = true;
        }
        else if (!Input.isMousePressed(Mouse.Button.Left))
        {
            wasClicked = false;
        }
    }
    public override void Draw()
    {
        if (!Visible)
            return;
        Render.Target?.Draw(Rectangle);
        Label.Draw();
    }
}
