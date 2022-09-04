[![NuGet version (Krane)](https://img.shields.io/nuget/v/Krane.svg)](https://www.nuget.org/packages/Krane)
[![GitHub](https://img.shields.io/github/license/Ker-Verse/Krane)](https://www.gnu.org/licenses/gpl-3.0.txt)

# Krane

Krane is a graphics framework for [C#](https://g.co/kgs/vxLHKK) built on top of [SFML.NET](https://github.com/SFML/SFML.Net)
It allows for fast and reliable graphics rendering on Windows.
## Dependencies
- [SFML.NET](https://github.com/SFML/SFML.Net)
## Installation

```powershell
dotnet add package Krane
```

## Usage

```csharp
using Krane.Core;

using(var mygame = new MyGame())
{
  mygame.Start();
}

class MyGame : Game
{
  public MyGame(uint Width = 400,uint Height = 400):base("MyTitle",Width,Height)
  {
    SetFPSLimit(30);
  }
  public override void Initialize()
  {
    //Insert Initialization Code Here
  }
  public override void Update()
  {
    SetTitle(GameTime.totalTime);  
  }
  public override void Draw()
  {
    Render.Clear();
    Render.Draw(new CircleShape(200));
  }
}
```
## Roadmap
### GUI
- Custom Textures for Buttons and Widgets
- Complete GUI system
### New Features
- Cameras
- Collision Detection

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[GNU General Public License v3.0](https://www.gnu.org/licenses/gpl-3.0.txt)
