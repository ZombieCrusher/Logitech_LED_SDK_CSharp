using System;
using System.Drawing;
using LogitechSDK;

public class Program
{
    static void Main(string[] args)
    {
        // Initialize the LED SDK
        bool LedInitialized = Logitech.InitialiseAPI("SetTargetZone Sample C#");

        if (!LedInitialized)
        {
            Console.WriteLine("Logitech.InitialiseAPI() failed.");
            return;
        }

        Console.WriteLine("LED SDK Initialized");

        Logitech.SetLEDTargetDevice(TargetDevice.ALL);

        // Set all devices to Black
        Logitech.SetLEDLighting(Color.Black);

        // Set some keys on keyboard
        Logitech.SetLEDLightOfKeyboardKey(KeyboardKeys.L, Color.Cyan);
        Logitech.SetLEDLightOfKeyboardKey(KeyboardKeys.O, Color.Cyan);
        Logitech.SetLEDLightOfKeyboardKey(KeyboardKeys.G, Color.Cyan);
        Logitech.SetLEDLightOfKeyboardKey(KeyboardKeys.I, Color.Cyan);

        // Set RGB mouse logo to Red
        Logitech.SetLEDLightForTargetZoneForMouse(TargetZoneMouse.LOGO_SIDE, Color.Red);

        // Set G213 keyboard zones to Red, Yellow, Green, Cyan, Blue
        Logitech.SetLEDLightForTargetZoneForKeyboard(TargetZoneKeyboard.LEFT_SIDE, Color.Red);
        Logitech.SetLEDLightForTargetZoneForKeyboard(TargetZoneKeyboard.CENTRE_SIDE, Color.Yellow);
        Logitech.SetLEDLightForTargetZoneForKeyboard(TargetZoneKeyboard.RIGHT_SIDE, Color.Green);
        Logitech.SetLEDLightForTargetZoneForKeyboard(TargetZoneKeyboard.ARROW_KEYS_SIDE, Color.Cyan);
        Logitech.SetLEDLightForTargetZoneForKeyboard(TargetZoneKeyboard.NUMPAD_KEYS_SIDE, Color.Blue);

        // Set G633/G933 headset logos to White, backsides to Purple
        Logitech.SetLEDLightForTargetZoneForHeadset(TargetZoneHeadset.LOGO_SIDE, Color.White);
        Logitech.SetLEDLightForTargetZoneForHeadset(TargetZoneHeadset.BACK_SIDE, Color.Purple);

        Console.WriteLine("Press \"ENTER\" to continue...");
        Console.ReadLine();

        Console.WriteLine("LED SDK Shutting down");
        Logitech.Shutdown();
    }
}