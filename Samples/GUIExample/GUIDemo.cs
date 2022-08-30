using Krane.Core;
using Krane.GUI.Widgets;
using SFML.Graphics;
using SFML.System;

namespace GUIExample;
public class GUIDemo : Game
{
	Button Button;
	Label Label;
	public GUIDemo():base("GUI Example")
	{
		Button = new("Click me!",new Vector2f(10,10),new(100f,45f),TextColor:Color.Black);
		Label = new("Hello World!", new Vector2f(50, 90));
		Button.Clicked += (sender, _) => 
		{
			var btn = sender as Button;

			btn?.SetFillColor(btn.BackColor!=Color.Red?Color.Red:Color.White);
			btn?.Label.SetText(btn?.DisplayedText != "Bye" ? "Bye" : "Hello");
			Label.SetText(Label.DisplayedText == "Kerod" ? "Abem" : "Kerod");
		};
	}
	public override void Initialize()
	{

	}
	public override void Update()
	{
		Button.Update();
	}
	public override void Draw()
	{
		Render.Target.Clear();
		Button.Draw();
		Label.Draw();
	}
}
