using Krane.Core;
using Krane.Extensions;
using Krane.Preset;
namespace Krane.ParticleSystem;
// Probablistic Particle Emitter Class
// Description: A probabilistic particle emitter that emits particles given a range of possible values
// Stochastic values are EmissionRate, LifeTime, Rotation, AngularVelocity, AngularAcceleration, Size, SizeDelta, Alpha, AlphaDelta
public class ParticleEmitter
{
    public bool IsEmitting { get; set; } = true;
    public Vector2f Position { get; set; }
    public float Velocity { get; set; }
    public float Direction { get; set; }
    public float Acceleration { get; set; }
    public float EmissionRate { get; set; }
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
    public List<Particle> Particles { get; set; } = new();
    public float Timer { get; set; }
    // Variance
    public float EmissionRateVariance { get; set; }
    public float LifeTimeVariance { get; set; }
    public float RotationVariance { get; set; }
    public float AngularVelocityVariance { get; set; }
    public float AngularAccelerationVariance { get; set; }
    public float RadialGradientVariance { get; set; }
    public ColorF ColorVariance { get; set; }
    public Vector2f SizeVariance { get; set; }
    public Vector2f SizeDeltaVariance { get; set; }
    public float AlphaDeltaVariance { get; set; }

    public ParticleEmitter(Vector2f _position, float _velocity,float _direction, float _acceleration, float _emissionRate = 1, float _lifeTime = 1, float _rotation = 0, float _angularVelocity = 0, float _angularAcceleration = 0, ColorF? _color = null, Vector2f? _size = null, Vector2f? _sizeDelta = null, float _alpha = 1, float _alphaDelta = 0, Texture? _texture = null)
    {
        Initialize(_position, _velocity,_direction, _acceleration, _emissionRate, _lifeTime, _rotation, _angularVelocity, _angularAcceleration, _color, _size, _sizeDelta, _alpha, _alphaDelta, _texture);
    }

    public void Initialize(Vector2f _position, float _velocity,float _direction, float _acceleration, float _emissionRate, float _lifeTime, float _rotation, float _angularVelocity, float _angularAcceleration, ColorF? _color, Vector2f? _size, Vector2f? _sizeDelta, float _alpha, float _alphaDelta, Texture? _texture)
    {
        Position = _position;
        Velocity = _velocity;
        Direction = _direction;
        Acceleration = _acceleration;
        EmissionRate = _emissionRate;
        LifeTime = _lifeTime;
        Rotation = _rotation;
        AngularVelocity = _angularVelocity;
        AngularAcceleration = _angularAcceleration;
        Color = _color ?? new Color(255, 255, 255, 255);
        Size = _size ?? new Vector2f(1, 1);
        SizeDelta = _sizeDelta ?? new Vector2f(0, 0);
        Alpha = _alpha;
        AlphaDelta = _alphaDelta;
        Texture = _texture ?? Presets.Textures.Circle;
    }
    public void Update()
    {
        Timer += GameTime.DeltaTime.AsSeconds();
        if (Timer >= 1 / EmissionRate && IsEmitting)
        {
            Timer = 0;
            Particles.Add(new Particle(Position, Velocity, Direction, Acceleration, LifeTime + Random.Shared.RangeF(-LifeTimeVariance, LifeTimeVariance), Rotation + Random.Shared.RangeF(-RotationVariance, RotationVariance), AngularVelocity + Random.Shared.RangeF(-AngularVelocityVariance, AngularVelocityVariance), AngularAcceleration + Random.Shared.RangeF(-AngularAccelerationVariance, AngularAccelerationVariance), Color + ColorVariance, Size + SizeVariance, SizeDelta + SizeDeltaVariance, Alpha, AlphaDelta + Random.Shared.RangeF(-AlphaDeltaVariance, AlphaDeltaVariance), Texture));
        }
        for (int i = 0; i < Particles.Count; i++)
        {
            Particles[i].Update();
            if (Particles[i].LifeTime <= 0)
            {
                Particles.RemoveAt(i);
            }
        }
    }
    public void Draw()
    {
        foreach (var particle in Particles)
        {
            particle.Draw();
        }
    }
}

// Static Particle System Class
public static class ParticleSystem
{
    public static List<ParticleEmitter> Emitters { get; set; } = new List<ParticleEmitter>();

    public static void Add(ParticleEmitter emitter)
    {
        Emitters.Add(emitter);
    }
    public static void Remove(ParticleEmitter emitter)
    {
        Emitters.Remove(emitter);
    }
    public static void Update()
    {
        foreach (var emitter in Emitters)
        {
            emitter.Update();
        }
    }

    public static void Draw()
    {
        foreach (var emitter in Emitters)
        {
            emitter.Draw();
        }
    }
}