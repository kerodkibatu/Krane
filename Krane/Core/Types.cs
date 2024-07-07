using SFML.System;
namespace Krane.Core;

public struct ColorF
{
    public float R { get; set; }
    public float G { get; set; }
    public float B { get; set; }
    public float A { get; set; }

    public ColorF(float _r, float _g, float _b, float _a = 1)
    {
        R = _r;
        G = _g;
        B = _b;
        A = _a;
    }

    public static ColorF operator +(ColorF a, ColorF b)
    {
        return new ColorF(a.R + b.R, a.G + b.G, a.B + b.B, a.A + b.A);
    }

    public static ColorF operator -(ColorF a, ColorF b)
    {
        return new ColorF(a.R - b.R, a.G - b.G, a.B - b.B, a.A - b.A);
    }

    public static ColorF operator *(ColorF a, ColorF b)
    {
        return new ColorF(a.R * b.R, a.G * b.G, a.B * b.B, a.A * b.A);
    }

    public static ColorF operator /(ColorF a, ColorF b)
    {
        return new ColorF(a.R / b.R, a.G / b.G, a.B / b.B, a.A / b.A);
    }

    public static ColorF operator *(ColorF a, float b)
    {
        return new ColorF(a.R * b, a.G * b, a.B * b, a.A * b);
    }

    public static ColorF operator /(ColorF a, float b)
    {
        return new ColorF(a.R / b, a.G / b, a.B / b, a.A / b);
    }

    public static bool operator ==(ColorF a, ColorF b)
    {
        return a.R == b.R && a.G == b.G && a.B == b.B && a.A == b.A;
    }

    public static bool operator !=(ColorF a, ColorF b)
    {
        return a.R != b.R || a.G != b.G || a.B != b.B || a.A != b.A;
    }

    public override readonly bool Equals(object? obj)
    {
        return obj is ColorF f &&
               R == f.R &&
               G == f.G &&
               B == f.B;
    }
    public override readonly int GetHashCode() => HashCode.Combine(R, G, B, A);
    public static implicit operator Color(ColorF color)
    {
        return new Color((byte)(color.R * 255), (byte)(color.G * 255), (byte)(color.B * 255), (byte)(color.A * 255));
    }
    public static implicit operator ColorF(Color color)
    {
        return new ColorF(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
    }
    public static explicit operator ColorF(Vector3f vector)
    {
        return new ColorF(vector.X, vector.Y, vector.Z);
    }
    public static explicit operator Vector3f(ColorF color)
    {
        return new Vector3f(color.R, color.G, color.B);
    }
}
