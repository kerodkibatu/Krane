using Krane.Core;
using Krane.Resources;
using Krane.Interactive;

namespace Krane.GUI.Widgets;
public class Label : Widget
{
    public static Vector2f DefaultSize = new(150, 50);
    Text Text;

    public bool Centered;
    public override bool Visible { get; set; } = true;
    public override Vector2f Position => Text.Position;
    public string DisplayedText => Text.DisplayedString;
    public Color FillColor => Text.FillColor;
    public Color OutlineColor => Text.OutlineColor;
    public Label(string text, Vector2f Position, bool Centered = false, Color? FillColor = null, Color? Outline = null)
    {
        this.Centered = Centered;
        Text = new Text(text, FontManager.Default)
        {
            FillColor = FillColor ?? Color.White,
            OutlineColor = Outline ?? Color.Transparent,
            OutlineThickness = 1
        };
        Text.Position = Position;
        CenterText();
    }
    void CenterText()
    {
        if (!Centered)
            return;
        var textBound = Text.GetLocalBounds();
        Text.Origin = new Vector2f(textBound.Width, textBound.Height+15f) / 2;
    }
    public void SetTextColor(Color Fill, Color? Outline = null)
    {
        Text.FillColor = Fill;
        Text.OutlineColor = Outline ?? Color.Transparent;
    }
    public void SetTextSize(uint Size)
    {
        Text.CharacterSize = Size;
        CenterText();
    }
    public void SetFont(Font font)
    {
        Text.Font = font;
        CenterText();
    }
    public void SetText(string str)
    {
        Text.DisplayedString = str;
        CenterText();
    }
    public override void Update()
    {

    }
    public override void Draw()
    {
        if (!Visible)
            return;
        Render.Target?.Draw(Text);
    }
}
