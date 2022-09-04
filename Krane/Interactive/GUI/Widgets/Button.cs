using Krane.Core;

namespace Krane.Interactive.GUI.Widgets;
public class Button : Widget
{
    public static Vector2f DefaultSize = new(150, 50);

    RectangleShape ClickArea;
    bool wasClicked = false;

    public Label Label;
    public override bool Visible { get; set; } = true;
    public override Vector2f Position => ClickArea.Position;
    public string DisplayedText => Label.DisplayedText;
    public EventHandler? Clicked { get; set; }

    public Button(string text, Vector2f Position, Vector2f? Size = null, Color? FillColor = null, Color? Outline = null,Color? TextColor = null,uint TextSize = 32)
    {
        ClickArea = new(Size ?? DefaultSize)
        {
            Position = Position,
            FillColor = FillColor ?? Color.White,
            OutlineColor = Outline ?? Color.Transparent,
            OutlineThickness = 1
        };
        Label = new(text, ClickArea.Position+ClickArea.Size*0.5f,Centered:true,FillColor:TextColor,TextSize: TextSize);
    }
    public void SetColor(Color Fill, Color? Outline = null)
    {
        ClickArea.FillColor = Fill;
        ClickArea.OutlineColor = Outline ?? Color.Transparent;
    }
    public void SetTextColor(Color Fill, Color? Outline = null)
    {
        Label.SetTextColor(Fill, Outline);
    }
    public override void Update()
    {
        if (!Visible)
            return;
        var MousePos = Input.mousePosition;
        if (ClickArea.GetGlobalBounds().Contains(MousePos.X, MousePos.Y) 
            && Input.IsMouseDown(Mouse.Button.Left) 
            && !Input.WasMouseDown(Mouse.Button.Left))
        {
            Clicked?.Invoke(this, new());
        }
    }
    public override void Draw()
    {
        if (!Visible)
            return;
        Render.Target?.Draw(ClickArea);
        Label.Draw();
    }
}
