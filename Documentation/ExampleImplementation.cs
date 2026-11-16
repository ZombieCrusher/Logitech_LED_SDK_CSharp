using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogitechSDK;

public class Program
{
    static void Main(string[] args)
    {
        // Initialize the LED SDK
        bool LedInitialized = LogitechNative.LogiLedInitWithName("SetTargetZone Sample C#");

        if (!LedInitialized)
        {
            Console.WriteLine("LogitechNative.LogiLedInit() failed.");
            return;
        }

        Console.WriteLine("LED SDK Initialized");

        LogitechNative.LogiLedSetTargetDevice(LogitechNative.LOGI_DEVICETYPE_ALL);

        // Set all devices to Black
        LogitechNative.LogiLedSetLighting(0, 0, 0);

        // Set some keys on keyboard
        LogitechNative.LogiLedSetLightingForKeyWithKeyName(keyboardNames.L, 0, 100, 100);
        LogitechNative.LogiLedSetLightingForKeyWithKeyName(keyboardNames.O, 0, 100, 100);
        LogitechNative.LogiLedSetLightingForKeyWithKeyName(keyboardNames.G, 0, 100, 100);
        LogitechNative.LogiLedSetLightingForKeyWithKeyName(keyboardNames.I, 0, 100, 100);

        // Set RGB mouse logo to Red
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Mouse, 1, 100, 0, 0);

        // Set G213 keyboard zones to Red, Yellow, Green, Cyan, Blue
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 1, 100, 0, 0);
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 2, 100, 100, 0);
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 3, 0, 100, 0);
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 4, 0, 100, 100);
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Keyboard, 5, 0, 0, 100);

        // Set G633/G933 headset logos to White, backsides to Purple
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Headset, 0, 100, 100, 100);
        LogitechNative.LogiLedSetLightingForTargetZone(DeviceType.Headset, 1, 100, 0, 100);

        Console.WriteLine("Press \"ENTER\" to continue...");
        Console.ReadLine();

        Console.WriteLine("LED SDK Shutting down");
        LogitechNative.LogiLedShutdown();
    }
}