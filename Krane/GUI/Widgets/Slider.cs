using Krane.Core;
using Krane.Interactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krane.GUI.Widgets
{
    public class Slider : Widget
    {
        public static Vector2f DefaultSize = new(150f, 40f);

        public override bool Visible { get; set; }

        public override Vector2f Position => OuterRect.Position;

        public override Color FillColor { get => InnerRect.FillColor; set => InnerRect.FillColor = value; }
        public override Color OutlineColor { get => OuterRect.OutlineColor; set => OuterRect.OutlineColor = value; }

        RectangleShape OuterRect;
        RectangleShape InnerRect;
        public EventHandler<float>? ValueChanged;
        public float Value { get; set; }
        float MinVal, MaxVal;
        Vector2f sliderSize;
        public Slider(float Min,float Max, Vector2f Position, Vector2f? Size = null,float Value = 0,int Inset = 5, Color? Fill = null, Color? Outline = null)
        {
            (MinVal, MaxVal) = (Min, Max);
            OuterRect = new(Size ?? DefaultSize)
            {
                Position = Position,
                FillColor = Color.Transparent,
                OutlineColor = Outline ?? Color.White,
                OutlineThickness = 1,
            };
            InnerRect = new(OuterRect.Size-new Vector2f(Inset,Inset)*2)
            {
                Position = OuterRect.Position+new Vector2f(Inset,Inset),
                FillColor = Fill??Color.White,
                OutlineColor = Color.Transparent
            };
            sliderSize = InnerRect.Size;
            this.Value = Value;
            Refresh();
        }
        public void SetVal(float newVal)
        {
            Value = newVal;
            Value = Value > MaxVal ? MaxVal : Value < MinVal ? MinVal : Value;
            ValueChanged?.Invoke(this, Value);
            Refresh();
        }
        public void Refresh()
        {
            InnerRect.Size = new Vector2f(sliderSize.X*map(Value,MinVal,MaxVal,0,1),sliderSize.Y);
        }
        float map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
        public override void Update()
        {
            if (!Visible)
                return;
            var MousePos = Input.GetMousePosition();
            if (OuterRect.GetGlobalBounds().Contains(MousePos.X, MousePos.Y) && Input.IsButtonPressed(Mouse.Button.Left))
            {
                var Bounds = OuterRect.GetGlobalBounds();
                SetVal(map(MousePos.X,Bounds.Left,Bounds.Width,MinVal,MaxVal));
            }
        }
        public override void Draw()
        {
            if (!Visible)
                return;
            Render.Draw(OuterRect);
            Render.Draw(InnerRect);
        }

    }
}
