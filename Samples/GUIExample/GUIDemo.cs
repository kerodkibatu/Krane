using Krane;
using Krane.Core;
using Krane.Interactive;
using Krane.Interactive.GUI;
using Krane.Interactive.GUI.Widgets;
using SFML.Graphics;
using SFML.System;

namespace GUIExample;
public class GUIDemo : Game
{
	Color backColor = Color.Black;
	CircleShape shape;
	public GUIDemo():base("GUI Example")
	{
        shape = new(10f)
        {
            Position = Input.mousePosition
        };
		shape.CenterOrigin();
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
			.AddWidget("cbox-backtoggle", new Checkbox("White BackGround", new(10f, 70f),FillColor:Color.Green,Outline:Color.Green,TextColor:Color.Green)
			{
				StateChanged = (sender, _) =>
				{
					ToggleBackColor();
				}
			})
			.AddWidget("sdr-slider",new Slider(5,50,120,new Vector2f(10,120),Size:new Vector2f(200,15))
			{
				ValueChanged = (sender, val) => { SetTitle(val.ToString()); }
			})
			);
	}
	public void ToggleBackColor()
	{
		shape.Position = Input.mousePosition;
        backColor = backColor == Color.Black ? Color.White : Color.Black;
    }
	public override void Update()
	{
		if (GameTime.Ticks%3==0)
			SetTitle(Input.deltaMouse.ToString());
		shape.Position += Input.deltaMouse * GameTime.deltaTime.AsSeconds();
	}
	public override void Draw()
	{
		Render.Clear(backColor);
		Render.Draw(shape);
	}
}
