using Krane.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krane.Extensions;
// Random Extensions
public static class RandomExtensions
{
    public static float NextFloat(this Random random, float min, float max)
    {
        return (float)random.NextDouble() * (max - min) + min;
    }

    public static float NextFloat(this Random random, float max)
    {
        return (float)random.NextDouble() * max;
    }

    public static float NextFloat(this Random random)
    {
        return (float)random.NextDouble();
    }

    public static double NextDouble(this Random random, double min, double max)
    {
        return random.NextDouble() * (max - min) + min;
    }

    public static double NextDouble(this Random random, double max)
    {
        return random.NextDouble() * max;
    }

    public static double NextDouble(this Random random)
    {
        return random.NextDouble();
    }
    public static int Range(this Random random, int min, int max)
    {
        return random.Next(min, max);
    }
    public static float RangeF(this Random random, float min, float max)
    {
        return random.NextFloat(min, max);
    }
    // ColorF
    public static ColorF NextColorF(this Random random, float r = 1, float g = 1, float b = 1)
    {
        return new ColorF(random.NextFloat(r), random.NextFloat(g), random.NextFloat(b));
    }
    public static ColorF NextColorF(this Random random, float r = 1, float g = 1, float b = 1, float a = 1)
    {
        return new ColorF(random.NextFloat(r), random.NextFloat(g), random.NextFloat(b), random.NextFloat(a));
    }
    public static ColorF RangeColorF(this Random random, float rMin, float rMax, float gMin, float gMax, float bMin, float bMax)
    {
        return new ColorF(random.NextFloat(rMin, rMax), random.NextFloat(gMin, gMax), random.NextFloat(bMin, bMax));
    }
}
