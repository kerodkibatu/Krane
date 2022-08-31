using Krane.Core;
using Krane.GUI;
using Krane.GUI.Widgets;
using SFML.Graphics;
using SFML.System;

namespace GUIExample;
public class GUIDemo : Game
{
	Color backColor = Color.Black;
	public GUIDemo():base("GUI Example")
	{

	}
	public override void Initialize()
	{
		GUIManager
			.AddGroup("main",
			new WidgetGroup()
			.AddWidget("btn-backtoggle", new Button("Toggle Background", new(10f, 10f), new(200f, 50f), Color.Green, Color.White, Color.White, 16)
			{
				Clicked = (sender, _) =>
				{
					(GUIManager.ActiveGroup?.GetWidget("cbox-backtoggle") as Checkbox)?.Toggle();
				}
			})
			.AddWidget("cbox-backtoggle", new Checkbox("White BackGround", new(10f, 70f),FillColor:Color.Green,Outline:Color.Green,TextColor:Color.Blue)
			{
				StateChanged = (sender, _) =>
				{
					ToggleBackColor();
				}
			})
			);
	}
	public void ToggleBackColor()
	{
        backColor = backColor == Color.Black ? Color.White : Color.Black;
    }
	public override void Update()
	{

	}
	public override void Draw()
	{
		Render.Clear(backColor);
	}
}
