using Krane.Core;

namespace Krane.Interactive.GUI.Widgets;
public class Checkbox : Widget
{
    public static uint DefaultSize = 32;
    public override bool Visible { get; set; } = true;

    bool _checked = false;

    public override Vector2f Position => ToggleArea.Position;
    public EventHandler<bool>? StateChanged { get; set; }
    public RectangleShape ToggleArea;
    public RectangleShape Indicator;


    public bool Checked { get { return _checked; } set { StateChanged?.Invoke(this, _checked = value); } }

    public Label Label;
    public Checkbox(string text, Vector2f Position, uint? Size = null, Color? FillColor = null, Color? Outline = null, Color? TextColor = null)
    {
        ToggleArea = new(new Vector2f(Size??DefaultSize, Size??DefaultSize))
        {
            Position = Position,
            FillColor = Color.Transparent,
            OutlineColor = Outline??Color.White,
            OutlineThickness = 1
        };
        Indicator = new(ToggleArea.Size * 0.9f)
        {
            Position = ToggleArea.Position+ToggleArea.Size/2f,
            FillColor = FillColor??Color.White,
        };
        Indicator.Origin = Indicator.Size / 2f;
        Label = new(text, new Vector2f(Position.X + ToggleArea.Size.X * 1.15f, Position.Y) - new Vector2f(0, Size ?? DefaultSize / 8f), FillColor:TextColor,TextSize:Size??DefaultSize);
    }
    public bool Toggle()
    {
        return Checked = !Checked;
    }
    public override void Update()
    {
        if (!Visible)
            return;
        var MousePos = Input.mousePosition;
        if (ToggleArea.GetGlobalBounds().Contains(MousePos.X, MousePos.Y) && Input.IsMouseDown(Mouse.Button.Left) && !Input.WasMouseDown(Mouse.Button.Left))
        {
            Toggle();
        }
    }
    public override void Draw()
    {
        if (!Visible)
            return;
        Render.Draw(ToggleArea);
        if (Checked)
            Render.Draw(Indicator);
        Label.Draw();
    }

}
