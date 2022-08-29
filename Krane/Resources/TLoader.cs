namespace Krane.Resources;
static class TLoader
{
    static string BasePath;
    static Dictionary<string, Texture> Loaded;
    static TLoader()
    {
        Loaded = new();
        BasePath = Directory.GetCurrentDirectory();
    }

    public static void SetRoot(string basePath)
    {
        BasePath = basePath;
    }
    public static void Load(string name, string ext = "png")
    {
        Loaded.Add(name, new Texture(Path.Combine(BasePath, name + $".{ext}")));
    }
    public static void Unload(string name)
    {
        Loaded.Remove(name);
    }

    public static Texture Get(string name)
    {
        return Loaded[name] ?? throw new KeyNotFoundException($"\"{name}\" Not Found");
    }
}


