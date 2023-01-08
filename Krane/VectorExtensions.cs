using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krane
{
    public enum Direction
    {
        East = 0,
        SouthEast = 1,
        South = 2,
        SouthWest = 3,
        West = 4,
        NorthWest = 5,
        North = 6,
        NorthEast = 7,
    }
    public static class VectorExtensions
    {
        public static Vector2f Normalize(this Vector2f vector)
        {
            float length = vector.Length();

            if (length != 0)
            {
                return new Vector2f(vector.X / length, vector.Y / length);
            }
            else
            {
                return vector;
            }
        }
        public static Vector2f Clamp(this Vector2f Vec, Vector2f Min, Vector2f Max)
        {
            return new Vector2f(MathF.Max(Min.X, MathF.Min(Vec.X, Max.X)), MathF.Max(Min.Y, MathF.Min(Vec.Y, Max.Y)));
        }
        public static float Length(this Vector2f vector)
        {
            return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }
        public static float Distance(this Vector2f v1, Vector2f v2)
        {
            return (float)Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
        }
        public static Direction GetDirection(this Vector2f vector)
        {
            double angle = Math.Atan2(vector.Y, vector.X);

            if (angle >= -Math.PI / 8 && angle <= Math.PI / 8)
            {
                return Direction.East;
            }
            else if (angle >= 3 * Math.PI / 8 && angle <= 5 * Math.PI / 8)
            {
                return Direction.South;
            }
            else if (angle >= Math.PI / 8 && angle <= 3 * Math.PI / 8)
            {
                return Direction.SouthEast;
            }
            else if (angle >= 5 * Math.PI / 8 && angle <= 7 * Math.PI / 8)
            {
                return Direction.SouthWest;
            }
            else if (angle >= 7 * Math.PI / 8 && angle <= Math.PI || angle >= -Math.PI && angle <= -7 * Math.PI / 8)
            {
                return Direction.West;
            }
            else if (angle >= -7 * Math.PI / 8 && angle <= -5 * Math.PI / 8)
            {
                return Direction.NorthWest;
            }
            else if (angle >= -5 * Math.PI / 8 && angle <= -3 * Math.PI / 8)
            {
                return Direction.North;
            }
            else if (angle >= -3 * Math.PI / 8 && angle <= -Math.PI / 8)
            {
                return Direction.NorthEast;
            }
            else
            {
                throw new ArgumentOutOfRangeException(angle + " is out of range");
            }

        }
    }
}
