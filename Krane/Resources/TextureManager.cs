namespace Krane.Resources;
static class TextureManager
{
    static string BasePath = Directory.GetCurrentDirectory();
    static Dictionary<string, Texture> Textures = new();
    public static void SetBasePath(string basePath) => BasePath = basePath;
    public static void Load(string alias, string fName) => Textures.Add(alias, new Texture(File.ReadAllBytes(Path.Combine(BasePath, fName))));
    public static void Remove(string alias) => Textures.Remove(alias);
    public static Texture Get(string alias) => Textures[alias] ?? throw new KeyNotFoundException($"Texture '{alias}' not found");
    public static Texture GetFromFile(string fName) => new Texture(File.ReadAllBytes(Path.Combine(BasePath, fName)));
}


