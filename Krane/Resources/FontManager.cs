using SFML.Window;

namespace Krane.Resources;
public static class FontManager
{
    static string BasePath;
    public static Font? Default;
    static Dictionary<string, Font> Fonts;
    static FontManager()
    {
        Fonts = new();
        BasePath = "C:\\Windows\\Fonts";
        Default = new("C:\\Windows\\Fonts\\CascadiaMono.ttf");
    }
    public static void Initialize(string basePath)
    {
        BasePath = basePath;
    }
    public static void Load(string name, string ext = "ttf")
    {
        Fonts.Add(name, new Font(Path.Combine(BasePath, name + "." + ext)));
    }
    public static void UnLoad(string name)
    {
        Fonts.Remove(name);
    }
}
