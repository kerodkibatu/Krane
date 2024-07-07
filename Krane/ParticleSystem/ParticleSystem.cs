using Krane.Core;
using Krane.Preset;
namespace Krane.ParticleSystem;
// Particle Class
public class Particle
{
    public Vector2f Position { get; set; }
    public float Velocity { get; set; }
    public float Direction { get; set; }
    public float Acceleration { get; set; }
    public float LifeTime { get; set; }
    public float Rotation { get; set; }
    public float AngularVelocity { get; set; }
    public float AngularAcceleration { get; set; }
    public ColorF Color { get; set; }
    public Vector2f Size { get; set; }
    public Vector2f SizeDelta { get; set; }
    public float Alpha { get; set; }
    public float AlphaDelta { get; set; }
    public Texture? Texture { get; set; }

    public Particle(Vector2f _position, float _velocity, float _direction, float _acceleration, float _lifeTime = 1, float _rotation = 0, float _angularVelocity = 0, float _angularAcceleration = 0, ColorF? _color = null, Vector2f? _size = null, Vector2f? _sizeDelta = null, float _alpha = 1, float _alphaDelta = 0, Texture? _texture = null)
    {
        Initialize(_position, _velocity,_direction, _acceleration, _lifeTime, _rotation, _angularVelocity, _angularAcceleration, _color, _size, _sizeDelta, _alpha, _alphaDelta, _texture);
    }

    public void Initialize(Vector2f _position, float _velocity, float _direction, float _acceleration, float _lifeTime, float _rotation, float _angularVelocity, float _angularAcceleration, ColorF? _color, Vector2f? _size, Vector2f? _sizeDelta, float _alpha, float _alphaDelta, Texture? _texture)
    {
        Position = _position;
        Direction = _direction;
        Velocity = _velocity;
        Acceleration = _acceleration;
        LifeTime = _lifeTime;
        Rotation = _rotation;
        AngularVelocity = _angularVelocity;
        AngularAcceleration = _angularAcceleration;
        Color = _color ?? new Color(255, 255, 255, 255);
        Size = _size ?? new Vector2f(1, 1);
        SizeDelta = _sizeDelta ?? new Vector2f(0, 0);
        Alpha = _alpha;
        AlphaDelta = _alphaDelta;
        Texture = _texture ?? Presets.Textures.Square;
    }

    public void Update()
    {
        Vector2f vel = new Vector2f(MathF.Cos(Direction) * Velocity, MathF.Sin(Direction) * Velocity);
        Position += vel;
        Velocity += Acceleration;
        Rotation += AngularVelocity;
        AngularVelocity += AngularAcceleration;
        Size += SizeDelta;
        Alpha += AlphaDelta;
        LifeTime -= GameTime.DeltaTime.AsSeconds();
    }

    public void Draw()
    {
        var sprite = new Sprite(Texture);
        sprite.Position = Position;
        sprite.Rotation = Rotation;
        sprite.Scale = Size;
        sprite.Color = new ColorF(Color.R - Alpha, Color.G - Alpha, Color.B - Alpha, Color.A - Alpha);
        Render.Draw(sprite);
    }
}