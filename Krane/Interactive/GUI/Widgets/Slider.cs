using Krane.Core;

namespace Krane.Interactive.GUI.Widgets
{
    public class Slider : Widget
    {
        public static Vector2f DefaultSize = new(150f, 40f);

        public override bool Visible { get; set; }

        public override Vector2f Position => OuterRect.Position;

        RectangleShape OuterRect;
        RectangleShape InnerRect;
        CircleShape Knob;

        public EventHandler<float>? ValueChanged;
        float value;
        public float Value { get => value; set => SetVal(value); }
        readonly float minVal, maxVal;
        public bool smoothValues { get; set; }
        readonly Vector2f sliderSize;
        public Slider(float Value, float Min, float Max
            , Vector2f Position, Vector2f? Size = null
            , Color? Fill = null, Color? Outline = null, Color? KnobFill = null, Color? KnobOutline = null
            , int Inset = 1, bool smoothValues = false)
        {
            this.smoothValues = smoothValues;
            (minVal, maxVal) = (Min, Max);
            OuterRect = new(Size ?? DefaultSize)
            {
                Position = Position,
                FillColor = Color.Transparent,
                OutlineColor = Outline ?? Color.White,
                OutlineThickness = 1,
            };
            InnerRect = new(sliderSize = OuterRect.Size - new Vector2f(Inset, Inset) * 2)
            {
                Position = OuterRect.Position + new Vector2f(Inset, Inset),
                FillColor = Fill ?? Color.White,
                OutlineColor = Color.Transparent
            };
            Knob = new(sliderSize.Y / 2f)
            {
                FillColor = KnobFill ?? new Color(120, 120, 120),
                OutlineColor = KnobOutline ?? Color.Black,
                OutlineThickness = 1,
            };
            Knob.CenterOrigin();
            SetVal(Value);
            Refresh();
        }
        public void SetVal(float newVal)
        {
            if (Value == newVal)
                return;
            value = smoothValues ? newVal : (int)newVal;
            value = value > maxVal ? maxVal : value < minVal ? minVal : value;
            ValueChanged?.Invoke(this, value);
            Refresh();
        }
        public void Refresh()
        {
            InnerRect.Size = new Vector2f(sliderSize.X * map(value, minVal, maxVal, 0, 1), sliderSize.Y);
            Knob.Position = new(InnerRect.Position.X + sliderSize.X * map(Value, minVal, maxVal, 0, 1), InnerRect.Position.Y + sliderSize.Y / 2f);
        }
        float map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
        public override void Update()
        {
            if (!Visible)
                return;
            var mousePos = Input.mousePosition;
            var sliderBounds = new FloatRect(InnerRect.Position, sliderSize);
            var knobBounds = Knob.GetGlobalBounds();
            if ((sliderBounds.Contains(mousePos.X, mousePos.Y) || knobBounds.Contains(mousePos.X, mousePos.Y)) && Input.IsMouseDown(Mouse.Button.Left))
            {
                SetVal(map(mousePos.X, sliderBounds.Left, sliderBounds.Left + sliderBounds.Width - 1, minVal, maxVal));
            }
            else if (sliderBounds.Contains(mousePos.X, mousePos.Y))
            {
                SetVal(Value + Input.scrollDelta);
            }
        }
        public override void Draw()
        {
            if (!Visible)
                return;
            Render.Draw(OuterRect);
            Render.Draw(InnerRect);
            Render.Draw(Knob);
        }

    }
}
