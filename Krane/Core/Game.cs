namespace Krane.Core;
public abstract class Game : IDisposable
{
    private RenderWindow Window;
    private CancellationTokenSource cancellationTokenSource;

    public View CurrentView => Window.GetView();
    public uint WIDTH, HEIGHT;
    public bool HasFocus => Window.HasFocus();
    public bool pauseOnFocusLost;
    public bool Paused;

    public Game((uint Width, uint Height) WindowSize, string Title = "Window", uint FPSLimit = 60)
    {
        (WIDTH, HEIGHT) = (WindowSize.Width, WindowSize.Height);
        Window = new RenderWindow(new VideoMode(WIDTH, HEIGHT), Title);
        SetFPSLimit(FPSLimit);
        Render.SetTarget(Window);
    }

    public void Pause(bool paused = true) => Paused = paused;
    public void SetFPSLimit(uint Limit) => Window.SetFramerateLimit(Limit);
    public void SetTitle(string newTitle) => Window.SetTitle(newTitle);

    public void Start(CancellationToken? cancellationToken = null)
    {
        cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken ?? CancellationToken.None);
        Window.Closed += (_, _) =>
        {
            Window.Close();
            cancellationTokenSource.Cancel();
        };
        Window.Resized += (_, e) => Window.Size = new Vector2u(e.Width, e.Height);
        Initialize();
        while (Window.IsOpen && !cancellationTokenSource.Token.IsCancellationRequested)
        {
            if (Paused || (!HasFocus && pauseOnFocusLost))
                continue;
            Window.DispatchEvents();
            GameTime.Tick();
            Input.Update();
            Update();
            Draw();
            Window.Display();
            Input.ResetDeltas();
        }
    }

    public virtual void Initialize() { }
    public virtual void Update() { }
    public virtual void Draw() { }
    public void Dispose()
    {
        cancellationTokenSource?.Dispose();
        GC.SuppressFinalize(this);
    }
}

