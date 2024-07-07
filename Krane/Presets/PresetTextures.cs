namespace Krane.Preset;
public static class Presets
{
    public static PresetTextures Textures = new PresetTextures();
}
public class PresetTextures
{
    // square texture
    public Texture Square
    {
        get
        {
            var squareTx = new Texture(1, 1);
            squareTx.Update(new byte[] { 255, 255, 255, 255 }, 1, 1, 0, 0);
            return squareTx;
        }
    }
    // circle texture
    public Texture Circle
    {
        get
        {
            var circleTx = new RenderTexture(1, 1);
            circleTx.Clear(new Color(255, 255, 255, 0));
            circleTx.Draw(new CircleShape(0.5f)
            {
                Position = new Vector2f(0.5f, 0.5f),
                FillColor = new Color(255, 255, 255, 255)
            }, new RenderStates(BlendMode.Alpha));
            return circleTx.Texture;
        }
    }
}
