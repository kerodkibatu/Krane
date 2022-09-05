using Krane;
using Krane.Core;
using Krane.Interactive;
using Krane.Interactive.GUI;
using Krane.Interactive.GUI.Widgets;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Simulation : Game
{
    public CircleShape ball;
    public Vector2f vel;
    public Simulation()
    {
        SetTitle("Bouncing Ball");
        ball = new(10f);
        ball.CenterOrigin();
        ball.SetPosition(WIDTH / 2, HEIGHT / 2);
    }
    public override void Initialize()
    {
        GUIManager.AddGroup("main",
            new WidgetGroup()
                .AddWidget(
                    "guide-text",
                    new Label("Press the left mouse button to" +
                              "\nforce the ball towards cursor."
                        , new Vector2f(10, 10)
                        , TextSize: 18)
                )
            );
    }

    public override void Update()
    {
        vel += new Vector2f(0, 10f) * GameTime.deltaTime.AsSeconds();
        if (ball.Position.Y >= HEIGHT - ball.Radius || ball.Position.Y <= ball.Radius)
        {
            vel.Y *= -0.6f;
        }
        if (ball.Position.X <= ball.Radius || ball.Position.X >= WIDTH - ball.Radius)
        {
            vel.X *= -1f;
        }
        if (Input.IsMouseDown(Mouse.Button.Left))
        {
            vel += (Input.mousePosition - ball.Position).Normalize();
        }
        ball.Position += vel *= (99 / 100f);
        ball.Position = ball.Position.Clamp(new(ball.Radius, ball.Radius), new(WIDTH - ball.Radius, HEIGHT - ball.Radius));
    }

    public override void Draw()
    {
        Render.Clear();
        Render.Draw(ball);
        if (Input.IsMouseDown(Mouse.Button.Left))
        {
            var forceLine = new LineShape(ball.Position, Input.mousePosition, Color.Green, Color.Red);
            Render.Draw(forceLine);
        }
        var velLine = new LineShape(ball.Position, ball.Position + vel * 5f, Color.Blue, Color.Green, 2);
        Render.Draw(velLine);
    }
}
