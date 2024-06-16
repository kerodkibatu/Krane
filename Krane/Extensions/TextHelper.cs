using SFML.Graphics;

namespace Krane.Resources
{
    public static class TextHelperExtensions
    {
        public static Text CenterOrigin(this Text text)
        {
            FloatRect bounds = text.GetLocalBounds();
            text.Origin = new Vector2f(bounds.Width / 2f, bounds.Height / 2f);
            return text;
        }

        public static Text SetPositionCentered(this Text text, Vector2f position)
        {
            FloatRect bounds = text.GetLocalBounds();
            text.Position = new Vector2f(position.X - bounds.Width / 2f, position.Y - bounds.Height / 2f);
            return text;
        }
        public static Text SetPosition(this Text t, float X, float Y)
        {
            t.Position = new Vector2f(X, Y);
            return t;
        }

    }
}
