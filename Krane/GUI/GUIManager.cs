namespace Krane.GUI;
public static class GUIManager
{
    static Dictionary<string, WidgetGroup> Groups;
    public static WidgetGroup? ActiveGroup;
    static GUIManager()
    {
        Groups = new();
    }
    public static void AddGroup(string name,WidgetGroup group)
    {
        Groups.Add(name,group);
        SetActiveGroup(name);
    }
    public static WidgetGroup GetGroup(string name)
    {
        return Groups[name]??throw new NullReferenceException();
    }
    public static void Hide()
    {
        foreach (var group in Groups)
        {
            group.Value.Hide();
        }
    }
    public static void Hide(string name)
    {
        GetGroup(name).Hide();
    }
    public static void Show()
    {
        foreach (var group in Groups)
        {
            group.Value.Show();
        }
    }
    public static void Show(string name)
    {
        GetGroup(name).Show();
    }
    public static void SetActiveGroup(string name)
    {
        Hide();
        Show(name);
        ActiveGroup = GetGroup(name);
    }
    public static void Update()
    {
        ActiveGroup?.Update();
    }
    public static void Draw()
    {
        ActiveGroup?.Draw();
    }

}
