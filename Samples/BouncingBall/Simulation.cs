using Krane.Core;
using Krane.Extensions;
using Krane.Resources;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Simulation : Game
{
    CircleShape ball;
    Vector2f vel;
    float pullForce = 2f;
    float gravity = 30f;
    public Simulation():base((640,480),"Bouncing Ball")
    {
        ball = new CircleShape(10f).SetPosition(WIDTH/2,HEIGHT/2).CenterOrigin();
    }
    public override void Update()
    {
        if (ball.Position.Y >= HEIGHT - ball.Radius || ball.Position.Y <= ball.Radius)
        {
            vel = vel.Negate(Axis.Y).Mul(y:0.6f);
        }
        if (ball.Position.X <= ball.Radius || ball.Position.X >= WIDTH - ball.Radius)
        {
            vel =  vel.Negate(Axis.X);
        }
        if (Input.IsMouseDown(Mouse.Button.Left))
        {
            vel += (Input.MousePos - ball.Position).Normalize().Mul(pullForce);
        }
        vel += new Vector2f(0, gravity) * GameTime.DeltaTime.AsSeconds();
        ball.Position += vel *= 0.99f;
        ball.Position = ball.Position.Clamp(new(ball.Radius, ball.Radius), new(WIDTH - ball.Radius, HEIGHT - ball.Radius));
    }

    public override void Draw()
    {
        Render.Clear();
        // Add Help Text
        var helpText = new Text("Click and drag to apply force", FontManager.Active, 20).SetPosition(10, 10);
        Render.Draw(helpText);
        if (Input.IsMouseDown(Mouse.Button.Left))
        {
            var forceLine = new LineShape(ball.Position, Input.MousePos, startColor:Color.Green, endColor:Color.Red);
            Render.Draw(forceLine);
        }
        var velLine = new LineShape(ball.Position, ball.Position + vel * 5f,startColor:Color.Blue, endColor:Color.Green);
        Render.Draw(velLine);
        Render.Draw(ball);
    }
}
