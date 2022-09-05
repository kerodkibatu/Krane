using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krane
{
    public class LineShape : Shape,Drawable
    {
        Vertex[] vertices = new Vertex[4];
        float thickness;
        Color startColor,endColor;
        Vector2f startPoint, endPoint;
        Vector2f direction;
        Vector2f offset;
        public LineShape(Vector2f point1, Vector2f point2,
            Color? color1 = null, Color? color2 = null, float thickness = 5f)
        {
            startPoint = point1;
            endPoint = point2;
            startColor = color1??Color.White;
            endColor = color2??startColor;
            this.thickness = thickness;
            Refresh();
        }
        public void Refresh()
        {
            direction = endPoint - startPoint;
            Vector2f unitDirection = direction / direction.Length();
            Vector2f unitPerpendicular = new(-unitDirection.Y, unitDirection.X);

            offset = thickness / 2f * unitPerpendicular;

            vertices[0].Position = startPoint + offset;
            vertices[1].Position = endPoint + offset;
            vertices[2].Position = endPoint - offset;
            vertices[3].Position = startPoint - offset;

            vertices[1].Color = startColor;
            vertices[2].Color = startColor;
            vertices[3].Color = endColor;
            vertices[0].Color = endColor;
        }
        public void SetThickness(float thickness)
        {
            this.thickness = thickness;
            Refresh();
        }
        public new void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(vertices, PrimitiveType.Quads,states);
        }

        public override uint GetPointCount()
        {
            return 4;
        }

        public override Vector2f GetPoint(uint index)
        {
            return index switch
            {
                0 => offset,
                1 => direction + offset,
                2 => direction - offset,
                3 => -offset,
                _ => new()
            };
        }
    }
}
