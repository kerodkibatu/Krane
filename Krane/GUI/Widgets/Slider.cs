using Krane.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krane.GUI.Widgets
{
    public class Slider : Widget
    {
        public static Vector2f DefaultSize = new(150f,40f);

        public override bool Visible { get; set; }

        public override Vector2f Position => OuterRect.Position;

        public override Color FillColor { get => InnerRect.FillColor; set => InnerRect.FillColor = value; }
        public override Color OutlineColor { get => OuterRect.OutlineColor; set => OuterRect.OutlineColor = value; }

        RectangleShape OuterRect;
        RectangleShape InnerRect;

        
        public Slider(string text, Vector2f Position, Vector2f? Size = null,int Inset = 5, Color? Fill = null, Color? Outline = null, Color? TextColor = null)
        {
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

        }

        public override void Update()
        {
            if (!Visible)
                return;
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
