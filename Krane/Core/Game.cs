using Krane.GUI;
using Krane.Interactive;

namespace Krane.Core;
public abstract class Game : IDisposable
{
    public static bool DEBUG = false;
    private RenderWindow Window;



    public View DefaultView => Window.GetView();


    public Game(string Title = "", uint Width = 640, uint Height = 480, uint FPSLimit = 60, bool Debug = false)
    {
        DEBUG = Debug;
        Window = new(new(Width, Height), Title);
        
        SetFPSLimit(FPSLimit);
        Render.SetTarget(Window);
        Input.SetWindow(Window);
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
            Update();
            GUIManager.Update();
            Draw();
            GUIManager.Draw();
            Window.Display();
        }
    }

    public abstract void Initialize();
    public abstract void Update();
    public abstract void Draw();

    public void Dispose() => GC.SuppressFinalize(this);
}

