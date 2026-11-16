using System.Drawing;
using System.Text;

namespace LogitechSDK
{
    public static class Logitech
    {
        public static bool InitialiseAPI()
        {
            return LogitechNative.LogiLedInit();
        }

        public static bool InitialiseAPI( string Name )
        {
            return LogitechNative.LogiLedInitWithName( Name );
        }

        public static bool GetConfigOptionNumber( string Configpath, out double OptionNumber )
        {
            return LogitechNative.LogiLedGetConfigOptionNumber( Configpath, out OptionNumber );
        }

        public static bool GetConfigOptionBool( string Configpath, out bool OptionBool )
        {
            return LogitechNative.LogiLedGetConfigOptionBool( Configpath, out OptionBool );
        }

        public static bool GetConfigOptionColor( string Configpath, out Color RecievedColor )
        {
            bool b = LogitechNative.LogiLedGetConfigOptionColor( Configpath, out int Red, out int Green, out int Blue );
            RecievedColor = Color.FromArgb( Red, Green, Blue );
            return b;
        }

        // Todo: Complete it as Idk what does this even do?
        public static bool LogiLedGetConfigOptionKeyInput( string Configpath )
        {
            StringBuilder sb = new();
            return LogitechNative.LogiLedGetConfigOptionKeyInput( Configpath, sb, sb.Capacity );
        }

        public static void SetLEDTargetDevice( TargetDevice Device )
        {
            LogitechNative.LogiLedSetTargetDevice( ( int ) Device );
        }

        public static string GetSDKVersion()
        {
            StringBuilder sb = new();
            LogitechNative.LogiLedGetSdkVersion( out int majorNum, out int minorNum, out int buildNum );

            sb.Append( majorNum );
            sb.Append( '.' );
            sb.Append( minorNum );
            sb.Append( '.' );
            sb.Append( buildNum );

            return sb.ToString();
        }

        public static bool SaveLEDCurrentLighting()
        {
            return LogitechNative.LogiLedSaveCurrentLighting();
        }

        public static bool SetLEDLighting( Color StartColor )
        {
            return LogitechNative.LogiLedSetLighting( ClampColorValueToPercentage( StartColor.R ), ClampColorValueToPercentage( StartColor.G ), ClampColorValueToPercentage( StartColor.B ) );
        }

        public static bool RestoreLEDLighting() 
        {
            return LogitechNative.LogiLedRestoreLighting();
        }

        public static bool FlashLEDLighting( Color NewColor, int msDuration, int msInterval )
        {
            return LogitechNative.LogiLedFlashLighting( ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ), msDuration, msInterval );
        }

        public static bool PulseLEDLighting( Color NewColor, int msDuration, int msInterval )
        {
            return LogitechNative.LogiLedPulseLighting( ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ), msDuration, msInterval );
        }

        public static bool StopLEDEffects()
        {
            return LogitechNative.LogiLedStopEffects();
        }

        public static bool ExcludeLEDKeysFromBitmap( KeyboardKeys[] Keys )
        {
            return LogitechNative.LogiLedExcludeKeysFromBitmap( Keys, Keys.Length );
        }

        public static bool SetLEDLightingFromBitmap( byte[] bytes ) 
        {
            return LogitechNative.LogiLedSetLightingFromBitmap( bytes );
        }

        public static bool SetLEDLightingForKeyWithScanCode( int KeyCode, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithScanCode( KeyCode, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SetLEDLightingForKeyWithHIDCode( int KeyCode, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithHidCode( KeyCode, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SetLEDLightingForKeyWithQuartzCode( int KeyCode, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithQuartzCode( KeyCode, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SetLEDLightOfKeyboardKey( KeyboardKeys Key, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithKeyName( Key, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SaveLEDLightingForKey( KeyboardKeys Key )
        {
            return LogitechNative.LogiLedSaveLightingForKey( Key );
        }

        public static bool RestoreLEDLightingForKey( KeyboardKeys Key )
        {
            return LogitechNative.LogiLedRestoreLightingForKey( Key );
        }

        public static bool SetLEDFlashSingleKey( KeyboardKeys Key, Color StartColor, int msDuration, int msInterval )
        {
            return LogitechNative.LogiLedFlashSingleKey( Key, ClampColorValueToPercentage( StartColor.R ), ClampColorValueToPercentage( StartColor.G ), ClampColorValueToPercentage( StartColor.B ), msDuration, msInterval );
        }

        public static bool SetLEDPulseSingleKey(KeyboardKeys Key, Color StartColor, Color EndColor, int msDuration, bool isInfinite)
        {
            return LogitechNative.LogiLedPulseSingleKey(Key, ClampColorValueToPercentage(StartColor.R), ClampColorValueToPercentage(StartColor.G), ClampColorValueToPercentage(StartColor.B), ClampColorValueToPercentage(EndColor.R), ClampColorValueToPercentage(EndColor.G), ClampColorValueToPercentage(EndColor.B), msDuration, isInfinite);
        }

        public static bool StopLEDEffectsOnKey( KeyboardKeys Key )
        {
            return LogitechNative.LogiLedStopEffectsOnKey( Key );
        }

        public static bool SetLEDLightForTargetZoneForHeadset( TargetZoneHeadset Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.HEADSET, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SetLEDLightForTargetZoneForKeyboard( TargetZoneKeyboard Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.KEYBOARD, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SetLEDLightForTargetZoneForMouse( TargetZoneMouse Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.MOUSE, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SetLEDLightForTargetZoneForMouseMat( TargetZoneMouseMat Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.MOUSE_MAT, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static bool SetLEDLightForTargetZoneForSpeaker( TargetZoneSpeaker Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.SPEAKER, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static void Shutdown()
        {
            LogitechNative.LogiLedShutdown();
        }

        private static sbyte ClampColorValueToPercentage( float Value )
        {
            return (sbyte)Math.Clamp( ( Value / 255 ) * 100, 0f, 100f );
        }
    }
}