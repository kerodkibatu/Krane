using Krane.Interactive.GUI;
using Krane.Interactive;

namespace Krane.Core;
public abstract class Game : IDisposable
{
    private RenderWindow Window;
    public View DefaultView => Window.GetView();
    public uint WIDTH, HEIGHT;
    public Game(string Title = "", uint Width = 640, uint Height = 480, uint FPSLimit = 60)
    {
        (WIDTH, HEIGHT) = (Width,Height);
        Window = new(new(Width, Height), Title);
        SetFPSLimit(FPSLimit);
        Render.SetTarget(Window);

    }
    public void SetFPSLimit(uint Limit)
    {
        Window.SetFramerateLimit(Limit);
    }
    public void SetTitle(string newTitle)
    { 
        Window.SetTitle(newTitle);
    }
    public void Start()
    {
        Window.Closed += (_, _) => Window.Close();
        Window.Resized += (_, e) => Window.Size = new(e.Width, e.Height);
        Initialize();
        while (Window.IsOpen)
        {
            Window.DispatchEvents();
            GameTime.Tick();
            GUIManager.Update();
            Input.Update();
            Update();
            Draw();
            GUIManager.Draw();
            Window.Display();
            Input.ResetDeltas();
        }
    }
    public abstract void Initialize();
    public abstract void Update();
    public abstract void Draw();
    public void Dispose() => GC.SuppressFinalize(this);
}

