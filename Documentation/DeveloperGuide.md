# Logitech LED SDK for C# — Developer Guide

This guide documents the managed API in `Logitech.cs`. It combines the behavior described in Logitech's SDK manuals with the behavior of this repository's C# wrapper. The public entry point is `LogitechSDK.Logitech`; `LogitechNative` is an internal P/Invoke implementation detail and should not be called by applications.

## What this library does

The wrapper calls Logitech's native `LogitechLedEnginesWrapper.dll` to control supported Logitech G device lighting. It can control broad device categories, individual keyboard keys, keyboard bitmaps, and device lighting zones. The native SDK and connected hardware determine which operations are supported.

The library targets .NET 10 on Windows. The native DLL must match the application's process architecture (x86 or x64). The project includes the corresponding DLL under `Library\x86` and `Library\x64`; see the [README](../README.md) for build commands.

## Basic usage and lifecycle

Initialize once before making lighting calls. Choose either `InitialiseAPI()` or `InitialiseAPI(string)`; the named overload supplies a display name for the integration. If initialization fails, do not continue with LED operations. Always call `Shutdown()` when finished, including when application code throws.

```csharp
using System;
using System.Drawing;
using LogitechSDK;

if (!Logitech.InitialiseAPI("My application"))
{
    Console.Error.WriteLine("Could not initialize the Logitech LED SDK.");
    return;
}

try
{
    Logitech.SetLEDTargetDevice(TargetDevice.PERKEY_RGB);

    if (!Logitech.SetLEDLightOfKeyboardKey(KeyboardKeys.G, Color.Lime))
    {
        Console.Error.WriteLine("The key lighting request failed.");
    }
}
finally
{
    Logitech.Shutdown();
}
```

The SDK saves current lighting and stops existing effects during initialization. Its manuals advise allowing some time after initialization before calling `SetLEDLighting`; they do not prescribe a particular delay. A `false` result from a `bool`-returning method means the native SDK did not complete that operation. Common causes include calling before initialization, an unavailable or disconnected Logitech software runtime, unsupported hardware, or invalid parameters. The wrapper does not throw or log on a native `false` result, so check the return value where one is provided.

## Color and targeting

Methods that accept `System.Drawing.Color` convert each RGB channel from the .NET range `0–255` to the SDK range `0–100`. The conversion truncates fractional percentages. The alpha component of `Color` is not passed to the SDK.

`SetLEDTargetDevice` sets the device *category* for subsequent operations; it does not select one physical device. `TargetDevice` is a flags enum, so combine categories with `|`. The native SDK defaults to all categories if no target is set. The C# wrapper's setter returns `void`, so it does not expose the native SDK's success result.

## API reference

All methods below are static members of `LogitechSDK.Logitech`. Unless stated otherwise, methods returning `bool` report the native operation's success.

### Initialization, configuration, and SDK information

| Method | Behavior |
| --- | --- |
| `InitialiseAPI()` | Initializes the native SDK without supplying an integration name. Call once before using lighting operations. |
| `InitialiseAPI(string Name)` | Initializes the SDK and supplies an integration display name. The vendor manual says the name is set only when the SDK is initialized for the first time. |
| `GetConfigOptionNumber(string Configpath, out double OptionNumber)` | Reads a numeric integration option, returning its configured value or its default through the `out` parameter. |
| `GetConfigOptionBool(string Configpath, out bool OptionBool)` | Reads a Boolean integration option. |
| `GetConfigOptionColor(string Configpath, out Color RecievedColor)` | Reads an RGB integration option and returns its color through the `out` parameter. Check the returned `bool` before using the output. |
| `LogiLedGetConfigOptionKeyInput(string Configpath)` | Queries a key-input integration option. This wrapper currently returns only success/failure; it does not expose the key value to the caller. |
| `GetSDKVersion()` | Returns the version as `major.minor.build`. The wrapper does not expose the native version call's success flag, so do not use this method to determine whether initialization succeeded. |

Configuration paths must identify options known to the Logitech integration/runtime. The native SDK manuals describe options as user-configurable values, with defaults used when a user has not changed them.

### General lighting and effects

| Method | Behavior |
| --- | --- |
| `SetLEDLighting(Color StartColor)` | Sets the color for devices in the current target category. The manual advises not calling this immediately after initialization. |
| `SaveLEDCurrentLighting()` | Saves current lighting so it can later be restored. On per-key devices, the saved state includes each key. |
| `RestoreLEDLighting()` | Restores the state saved by `SaveLEDCurrentLighting()`. |
| `FlashLEDLighting(Color NewColor, int msDuration, int msInterval)` | Flashes the target devices between the requested color and black. The SDK saves and restores lighting around the effect. Duration and interval are in milliseconds; duration `0` is the native SDK's infinite-duration value, stopped with `StopLEDEffects()`. |
| `PulseLEDLighting(Color NewColor, int msDuration, int msInterval)` | Runs the SDK's pulsing effect on the target devices, then restores saved lighting. Duration and interval are in milliseconds; duration `0` requests an infinite effect. |
| `StopLEDEffects()` | Stops a general flash or pulse effect. |

### Keyboard keys and bitmap lighting

Per-key operations require compatible per-key RGB hardware and an appropriate `TargetDevice` selection.

| Method | Behavior |
| --- | --- |
| `SetLEDLightOfKeyboardKey(KeyboardKeys Key, Color NewColor)` | Sets the color of a key selected by the `KeyboardKeys` enum. |
| `SetLEDLightingForKeyWithScanCode(int KeyCode, Color NewColor)` | Sets a key using a platform scan code. |
| `SetLEDLightingForKeyWithHIDCode(int KeyCode, Color NewColor)` | Sets a key using a HID code. |
| `SetLEDLightingForKeyWithQuartzCode(int KeyCode, Color NewColor)` | Sets a key using a Quartz code. |
| `SaveLEDLightingForKey(KeyboardKeys Key)` | Saves the current color of one key. |
| `RestoreLEDLightingForKey(KeyboardKeys Key)` | Restores the color previously saved for one key. |
| `SetLEDFlashSingleKey(KeyboardKeys Key, Color StartColor, int msDuration, int msInterval)` | Flashes one key between the requested color and black. Timing values are in milliseconds; duration `0` means run until stopped. |
| `SetLEDPulseSingleKey(KeyboardKeys Key, Color StartColor, Color EndColor, int msDuration, bool isInfinite)` | Pulses one key between the start and end colors. `msDuration` is in milliseconds; `isInfinite` controls whether the effect repeats indefinitely. |
| `StopLEDEffectsOnKey(KeyboardKeys Key)` | Stops an effect running on the specified key. |
| `ExcludeLEDKeysFromBitmap(KeyboardKeys[] Keys)` | Excludes the listed keys from subsequent bitmap lighting updates, allowing other key colors to be updated separately. |
| `SetLEDLightingFromBitmap(byte[] bytes)` | Applies a keyboard bitmap. The native SDK expects a 21-by-6 grid with four bytes per position (`Bitmap.SIZE`, 504 bytes total). Each position represents RGBA data; an alpha value of `0` leaves that key unchanged during the update. |

`KeyboardKeys` contains the key names and native key-name codes supported by the wrapper. Scan-code, HID-code, and Quartz-code methods expect codes in their respective code systems; they are not interchangeable. `SetLEDLightingFromBitmap` forwards the array directly to native code without validating its length, so provide a correctly sized buffer.

### Device zones

Each zone method sets one zone on all connected zonal devices of that type, subject to the current `TargetDevice` selection and hardware support. Zone availability and behavior can vary by device model.

| Method | Zone enum |
| --- | --- |
| `SetLEDLightForTargetZoneForHeadset(TargetZoneHeadset Zone, Color NewColor)` | `LOGO_SIDE` (0), `BACK_SIDE` (1) |
| `SetLEDLightForTargetZoneForKeyboard(TargetZoneKeyboard Zone, Color NewColor)` | `ENTIRE_KEYBOARD_SIDE` (0), `LEFT_SIDE` (1), `CENTRE_SIDE` (2), `RIGHT_SIDE` (3), `ARROW_KEYS_SIDE` (4), `NUMPAD_KEYS_SIDE` (5) |
| `SetLEDLightForTargetZoneForMouse(TargetZoneMouse Zone, Color NewColor)` | `OTHER_SIDE` (0), `LOGO_SIDE` (1) |
| `SetLEDLightForTargetZoneForMouseMat(TargetZoneMouseMat Zone, Color NewColor)` | `LOGO_SIDE` (0) |
| `SetLEDLightForTargetZoneForSpeaker(TargetZoneSpeaker Zone, Color NewColor)` | `FRONT_LEFT_SIDE` (0), `FRONT_RIGHT_SIDE` (1), `REAR_LEFT_SIDE` (2), `REAR_RIGHT_SIDE` (3) |

Mouse zone IDs are model-dependent. In particular, some mouse models combine lighting regions or do not support the generic IDs shown by the enum. Verify a zone on the target hardware rather than assuming every enum value exists on every device.

### Shutdown

| Method | Behavior |
| --- | --- |
| `Shutdown()` | Shuts down the native SDK. The vendor manual says shutdown restores the last saved lighting and frees SDK resources. |

## Enums and constants

- `TargetDevice` is a `[Flags]` enum: `MONOCHROME`, `RGB`, `PERKEY_RGB`, and `ALL`. Use it with `SetLEDTargetDevice`.
- `DeviceType` identifies the device family for zone operations: `KEYBOARD`, `MOUSE`, `MOUSE_MAT`, `HEADSET`, or `SPEAKER`.
- `KeyboardKeys` maps named keyboard keys to Logitech SDK key-name codes.
- `TargetZoneHeadset`, `TargetZoneKeyboard`, `TargetZoneMouse`, `TargetZoneMouseMat`, and `TargetZoneSpeaker` provide typed zone IDs for their corresponding methods.
- `Bitmap` defines the native bitmap dimensions: width `21`, height `6`, four bytes per position, and `SIZE` `504`.

The enum declarations in the [`Enums` folder](../Enums) are the source of truth for available names and numeric values.

## Native boundary and troubleshooting

- **Initialization returns `false`:** Check that Logitech's required software/runtime is installed and running, the process can load `LogitechLedEnginesWrapper.dll`, and the DLL architecture matches the application.
- **A lighting call returns `false`:** Confirm initialization succeeded, the target category and device support the requested operation, and the device connection/runtime is still available.
- **A zone has no visible effect:** Confirm the model supports zonal lighting and that the zone ID is valid for that model. Zone methods are not a substitute for per-key lighting.
- **Bitmap updates affect unexpected keys:** Check the 21-by-6 raster layout, four-byte RGBA data per position, exact 504-byte buffer size, and alpha values for positions meant to remain unchanged.
- **Native exceptions or missing DLL errors:** Verify the correct x86/x64 build and that `LogitechLedEnginesWrapper.dll` is beside the running application.

The C# methods wrap a native SDK rather than simulating devices. A successful return indicates that the SDK accepted the request; the actual visual result still depends on hardware, firmware, and Logitech software behavior.

## Reference material

- [Original Logitech Gaming LED SDK instructions](Instructions_SDK.pdf)
- [Logitech instructions for using the SDK with C#](Instructions_SDK_C%23.pdf)
- [Native function declarations included with this repository](../Header/LogitechLEDLib.h)
- [C# wrapper implementation](../Logitech.cs)
- [Native interop declarations](../LogitechNative.cs)
