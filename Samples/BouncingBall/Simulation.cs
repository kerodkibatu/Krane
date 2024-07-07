using Krane.Core;
using Krane.Extensions;
using Krane.ParticleSystem;
using Krane.Resources;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Simulation : Game
{
    ParticleEmitter dustEmmiter;
    CircleShape ball;
    Vector2f vel;
    float pullForce = 2f;
    float gravity = 30f;
    public Simulation() : base((1024, 1024), "Bouncing Ball")
    {
        ball = new CircleShape(10f).SetPosition(WIDTH / 2, HEIGHT / 2).CenterOrigin();
        dustEmmiter =
            new ParticleEmitter(
                _position: ball.Position,
                _velocity: 0,
                _direction: 0,
                _acceleration: 0,
                _emissionRate: 100f,
                _lifeTime: 100,
                _rotation: 0,
                _angularVelocity: 0,
                _angularAcceleration: 0,
                _color: new Color(255, 100, 100),
                _size: new Vector2f(10, 10),
                _sizeDelta: new Vector2f(0, 0),
                _alpha: 255,
                _alphaDelta: 0);
        ParticleSystem.Add(dustEmmiter);
    }
    public override void Update()
    {
        dustEmmiter.Position = ball.Position;
        dustEmmiter.Velocity = 10f;
        dustEmmiter.Direction = MathF.Atan2(0, -vel.X);
        if (ball.Position.Y >= HEIGHT - ball.Radius || ball.Position.Y <= ball.Radius)
        {
            vel = vel.Negate(Axis.Y).Mul(y: 0.6f);
        }
        if (ball.Position.X <= ball.Radius || ball.Position.X >= WIDTH - ball.Radius)
        {
            vel = vel.Negate(Axis.X);
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
            var forceLine = new LineShape(ball.Position, Input.MousePos, startColor: Color.Green, endColor: Color.Red);
            Render.Draw(forceLine);
        }
        var velLine = new LineShape(ball.Position, ball.Position + vel * 5f, startColor: Color.Blue, endColor: Color.Green);
        Render.Draw(velLine);
        Render.Draw(ball);
    }
}
