using SFML.Window;

namespace Krane.Resources;
public static class FontManager
{
    static string BasePath = "C:\\Windows\\Fonts";
    public static Font? Active = new ("C:\\Windows\\Fonts\\CascadiaMono.ttf");
    static Dictionary<string, Font> Fonts = new();
    public static void SetBasePath(string basePath) => BasePath = basePath;
    public static void Load(string alias, string fName) => Fonts.Add(alias, new Font(File.ReadAllBytes(Path.Combine(BasePath, fName))));
    public static void Remove(string alias) => Fonts.Remove(alias);
    public static void SetActive(string alias) => Active = Get(alias);
    public static Font Get(string alias) => Fonts[alias] ?? throw new KeyNotFoundException($"Font '{alias}' not found");
    public static Font GetFromFile(string fName) => new Font(File.ReadAllBytes(Path.Combine(BasePath, fName)));
}
