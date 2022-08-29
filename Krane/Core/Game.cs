namespace Krane.Core;
public class Game : IDisposable
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
    }
    public void SetFPSLimit(uint Limit)
    {
        Window.SetFramerateLimit(Limit);
    }
    public void Start()
    {
        if (Window.IsOpen)
        {
            Window.Close();
        }
        Window.Closed += (_, _) => Window.Close();
        Window.Resized += (_, e) => Window.Size = new(e.Width, e.Height);

        Initialize();
        while (Window.IsOpen)
        {
            Window.DispatchEvents();
            GameTime.Tick();
            Update();
            Draw();
            Window.Display();
        }
    }

    public virtual void Initialize(){}

    public virtual void Update(){}
    public virtual void Draw(){}

    public void Dispose() => Window.Dispose();
}

