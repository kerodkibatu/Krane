namespace Krane.Extensions;
[Flags]
public enum Axis
{
    X,
    Y,
    Both
}
public static class VectorHelper
{
    public static Vector2f Normalize(this Vector2f vector)
    {
        float length = vector.Length();
        if (length != 0)
            return new Vector2f(vector.X / length, vector.Y / length);
        else
            return vector;
    }
    public static Vector2f Clamp(this Vector2f Vec, Vector2f Min, Vector2f Max)
    {
        return new Vector2f(MathF.Max(Min.X, MathF.Min(Vec.X, Max.X)), MathF.Max(Min.Y, MathF.Min(Vec.Y, Max.Y)));
    }
    public static float Length(this Vector2f vector)
    {
        return MathF.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    }
    public static float LengthSquared(this Vector2f vector)
    {
        return vector.X * vector.X + vector.Y * vector.Y;
    }
    public static float Distance(this Vector2f v1, Vector2f v2)
    {
        return MathF.Sqrt(MathF.Pow(v1.X - v2.X, 2) + MathF.Pow(v1.Y - v2.Y, 2));
    }
    public static Vector2f Negate(this Vector2f vector, Axis axis)
    {
        switch (axis)
        {
            case Axis.X:
                vector.X *= -1;
                break;
            case Axis.Y:
                vector.Y *= -1;
                break;
            case Axis.Both:
                return vector *= -1;
        }
        return vector;
    }
    public static Vector2f Mul(this Vector2f vector, float x)
    {
        return vector.Mul(x, x);
    }
    public static Vector2f Mul(this Vector2f vector, float x = 1, float y = 1)
    {
        vector.X *= x;
        vector.Y *= y;
        return vector;
    }
    public static Vector2f Div(this Vector2f vector, float x)
    {
        return vector.Div(x, x);
    }
    public static Vector2f Div(this Vector2f vector, float x = 1, float y = 1)
    {
        vector.X /= x;
        vector.Y /= y;
        return vector;
    }
    public static Vector2f Sub(this Vector2f vector, float x)
    {
        return vector.Sub(x, x);
    }
    public static Vector2f Sub(this Vector2f vector, float x = 1, float y = 1)
    {
        vector.X -= x;
        vector.Y -= y;
        return vector;
    }
    public static Vector2f Add(this Vector2f vector, float x)
    {
        return vector.Add(x, x);
    }
    public static Vector2f Add(this Vector2f vector, float x = 1, float y = 1)
    {
        vector.X += x;
        vector.Y += y;
        return vector;
    }
    public static Vector2f Pow(this Vector2f vector, float x)
    {
        return vector.Pow(x, x);
    }
    public static Vector2f Pow(this Vector2f vector, float x, float y)
    {
        vector.X = MathF.Pow(vector.X, x);
        vector.Y = MathF.Pow(vector.Y, y);
        return vector;
    }
    public static Vector2f NextUnitVector(this Random random)
    {
        float angle = random.NextSingle() * MathF.PI;
        return new Vector2f(MathF.Sin(angle), MathF.Cos(angle));
    }
    public static float Heading(this Vector2f vector)
    {
        return MathF.Atan2(vector.Y, vector.X);
    }
}
