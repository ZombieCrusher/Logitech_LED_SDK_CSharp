# Logitech LED SDK for C#

A small C# wrapper for Logitech's Windows LED SDK. Use it to control supported Logitech G device lighting from a .NET application, including keyboard keys and device lighting zones.

> **Platform:** Windows x86 and x64.
> **Target framework:** .NET 10.

## Features

- Initialize and shut down the Logitech LED SDK.
- Set lighting for all supported devices or a selected device category.
- Set a keyboard key or a device lighting zone to an RGB color.
- Use typed enums for device categories, keyboard keys, and lighting zones.
- Native wrapper binaries are included for Windows x86 and x64.

## Requirements

- Windows (x86 or x64).
- The .NET 10 SDK to build the project.
- A compatible Logitech device and Logitech software/LED SDK runtime. Device and feature support depends on the device and installed Logitech software.

The native `LogitechLedEnginesWrapper.dll` files are included in `Library\x86` and `Library\x64`. The wrapper does not provide Linux or macOS support.

## Getting started

Clone the repository and build the library for x64:

```powershell
git clone https://github.com/ZombieCrusher/Logitech_LED_SDK_CSharp.git
cd Logitech_LED_SDK_CSharp
dotnet build .\LogitechSDK.csproj -c Release -p:Platform=x64
```

Use `-p:Platform=x86` instead to build for 32-bit Windows. The selected platform determines which matching native wrapper DLL is copied to the output.

In your .NET 10 application, reference `LogitechSDK.csproj` (or the built assembly) and use the public `Logitech` API:

```csharp
using System.Drawing;
using LogitechSDK;

if (!Logitech.InitialiseAPI())
{
    Console.Error.WriteLine("Could not initialize the Logitech LED SDK.");
    return;
}

try
{
    Logitech.SetLEDTargetDevice(TargetDevice.ALL);
    Logitech.SetLEDLight(Color.Black);
    Logitech.SetLEDLightOfKeyboardKey(KeyboardKeys.G, Color.Lime);
}
finally
{
    Logitech.Shutdown();
}
```

Initialization can fail if the required Logitech software/runtime is unavailable or no compatible device is available. Always shut down the SDK when your application is finished using it.

## Documentation and example

- [`Documentation/ExampleImplementation.cs`](Documentation/ExampleImplementation.cs) contains a larger sample using the native SDK calls.
- [`Documentation/Instructions_SDK_C%23.pdf`](Documentation/Instructions_SDK_C%23.pdf) contains the C# SDK instructions.
- [`Documentation/Instructions_SDK.pdf`](Documentation/Instructions_SDK.pdf) contains the original SDK instructions.
- [`Header/LogitechLEDLib.h`](Header/LogitechLEDLib.h) provides the native SDK declarations used as reference.

## Releasing

There is currently no automated release workflow or published NuGet package configured in this repository. To make a Windows binary release:

1. Update and verify the source, then build both supported architectures:

   ```powershell
   dotnet publish .\LogitechSDK.csproj -c Release -p:Platform=x64
   dotnet publish .\LogitechSDK.csproj -c Release -p:Platform=x86
   ```

2. Check the publish output for each architecture under `bin\x64\Release\net10.0\publish` and `bin\x86\Release\net10.0\publish`. Confirm that the matching `LogitechLedEnginesWrapper.dll` is present alongside the assembly.
3. Package each architecture's publish output separately. Include the license and any user-facing documentation needed by consumers. Do not redistribute Logitech's native binaries unless their applicable terms permit it.
4. Create a version tag, for example `v1.0.0`, and push it:

   ```powershell
   git tag v1.0.0
   git push origin v1.0.0
   ```

5. On GitHub, create a Release from that tag, add concise release notes, and attach the x64 and x86 archives. State the required .NET runtime and Windows architecture in the release notes.

These commands produce framework-dependent builds; users need a compatible .NET runtime. If the project target framework, versioning, or release automation changes, update these instructions to match.

## Contributing

Bug reports and focused improvements are welcome. Before opening a pull request:

1. Keep changes scoped and include a clear explanation of the behavior changed.
2. Build for both supported platforms with the `dotnet build .\LogitechSDK.csproj -c Release -p:Platform=x64` and `dotnet build .\LogitechSDK.csproj -c Release -p:Platform=x86` commands.
3. Test hardware-dependent changes on a compatible Windows system and Logitech device, and describe the setup and results.

Please avoid including personal data, proprietary SDK files, or binaries you do not have permission to redistribute.

## AI-use notice

AI assistance was used to prepare this README. No C# source code was generated or modified by AI as part of this documentation change.

## License and trademarks

This project is distributed under the [MIT License](LICENSE.md). The Logitech name and any Logitech product or SDK trademarks belong to their respective owners. This project is an independent wrapper and is not affiliated with or endorsed by Logitech. The included native Logitech SDK binaries may be subject to separate terms; consult the applicable Logitech documentation before redistribution.
