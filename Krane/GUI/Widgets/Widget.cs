namespace Krane.GUI.Widgets;
public abstract class Widget
{
    public abstract bool Visible { get; set; }
    public abstract Vector2f Position { get; }
    public abstract Color FillColor { get; set; }
    public abstract Color OutlineColor { get; set; }
    public abstract void Update();
    public abstract void Draw();
    public void Show()
    {
        Visible = true;
    }
    public void Hide()
    {
        Visible = false;
    }
}
