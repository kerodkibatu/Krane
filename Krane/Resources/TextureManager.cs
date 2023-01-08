namespace Krane.Resources;
static class TextureManager
{
    static string BasePath;
    static Dictionary<string, Texture> Textures;
    static TextureManager()
    {
        Textures = new();
        BasePath = Directory.GetCurrentDirectory();
    }

    public static void Initialize(string basePath)
    {
        BasePath = basePath;
    }
    public static void Load(string name, string ext = "png")
    {
        Textures.Add(name, new Texture(Path.Combine(BasePath, name + $".{ext}")));
    }
    public static void Unload(string name)
    {
        Textures.Remove(name);
    }

    public static Texture Get(string name)
    {
        return Textures[name] ?? throw new KeyNotFoundException($"\"{name}\" Not Found");
    }
}


