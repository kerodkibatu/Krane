using Krane.Core;
using Krane.GUI;
using Krane.GUI.Widgets;
using SFML.Graphics;
using SFML.System;

namespace GUIExample;
public class GUIDemo : Game
{
    private Color backColor = Color.Black;
    private int clickCount = 0;

    public GUIDemo() : base("GUI Example")
    {

    }

    public override void Initialize()
    {
        GUIManager
            .AddGroup("main",
            new WidgetGroup()
            .AddWidget("btn-backtoggle", new Button("Toggle Background", new(10f, 10f), new(200f, 50f), Color.Green, Color.White, Color.White, 18)
            {
                Clicked = (sender, _) =>
                {
                    (GUIManager.ActiveGroup?.GetWidget("cbox-backtoggle") as Checkbox)?.Toggle();
                }
            })
            .AddWidget("cbox-backtoggle", new Checkbox("White Background", new(10f, 70f), 40, FillColor: Color.Green, Outline: Color.Green, TextColor: Color.Blue)
            {
                StateChanged = (sender, _) =>
                {
                    ToggleBackColor();
                }
            })
            .AddWidget("btn-click", new Button("Click Me!", new(10f, 130f), new(200f, 50f), Color.Blue, Color.White, Color.White, 18)
            {
                Clicked = (sender, _) =>
                {
                    clickCount++;
                    UpdateTitleText();
                }
            })
            .AddWidget("lbl-clickcount", new Label("Click Count: 0", new(10f, 200f), true, Color.White, TextSize: 24))
            );
    }

    public void ToggleBackColor()
    {
        backColor = backColor == Color.Black ? Color.White : Color.Black;
        UpdateTitleText();
    }

    public void UpdateTitleText()
    {
        Label? lbl = GUIManager.ActiveGroup!.GetWidget("lbl-clickcount") as Label;

        lbl.SetText($"Click Count: {clickCount}");

        lbl.FillColor = backColor == Color.Black ? Color.White : Color.Black;
    }

    public override void Update()
    {

    }

    public override void Draw()
    {
        Render.Clear(backColor);
    }
}
