using Krane.Interactive.GUI.Widgets;

namespace Krane.Interactive.GUI;
public class WidgetGroup
{
	Dictionary<string, Widget> widgets;
	public WidgetGroup()
	{
		widgets = new();
	}
	public WidgetGroup AddWidget(string name,Widget widget)
	{
		widgets.Add(name,widget);
		return this;
	}
	public Widget GetWidget(string name)
	{
		return widgets[name]??throw new NullReferenceException();
	}
	public void Hide()
	{
		foreach (var widget in widgets)
		{
			widget.Value.Hide();
		}
	}
	public void Hide(string name)
	{
		GetWidget(name).Hide();
	}
    public void Show()
    {
        foreach (var widget in widgets)
        {
            widget.Value.Show();
        }
    }
    public void Show(string name)
    {
        GetWidget(name).Show();
    }
    public void Update()
	{
        foreach (var widget in widgets)
        {
            widget.Value.Update();
        }
    }
	public void Draw()
	{
        foreach (var widget in widgets)
        {
            widget.Value.Draw();
        }
    }
}
