namespace Krane.Interactive.GUI.Widgets;
public abstract class Widget
{
    public abstract bool Visible { get; set; }
    public abstract Vector2f Position { get; }
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
