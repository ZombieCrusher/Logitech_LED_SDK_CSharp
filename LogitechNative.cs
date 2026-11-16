using System.Runtime.InteropServices;
using System.Text;

namespace LogitechSDK
{
    internal static class LogitechNative
    {
        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedInit();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedInitWithName( string name );

        // ------------------ Config option functions ---------------------------
        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedGetConfigOptionNumber( [ MarshalAs( UnmanagedType.LPWStr ) ] string configPath, out double defaultNumber );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedGetConfigOptionBool( [ MarshalAs( UnmanagedType.LPWStr ) ] string configPath, out bool defaultRed );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedGetConfigOptionColor( [ MarshalAs( UnmanagedType.LPWStr ) ] string configPath, out int defaultRed, out int defaultGreen, out int defaultBlue );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode ) ]
        internal static extern bool LogiLedGetConfigOptionKeyInput( [ MarshalAs( UnmanagedType.LPWStr ) ] string configPath, StringBuilder buffer, int bufsize );
        // ----------------------------------------------------------------------

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetTargetDevice( int targetDevice );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedGetSdkVersion( out int majorNum, out int minorNum, out int buildNum );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSaveCurrentLighting();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetLighting( int redPercentage, int greenPercentage, int bluePercentage );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedRestoreLighting();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedFlashLighting( int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedPulseLighting( int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedStopEffects();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedExcludeKeysFromBitmap( KeyboardKeys[] keyList, int listCount );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetLightingFromBitmap( byte[] bitmap );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetLightingForKeyWithScanCode( int keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetLightingForKeyWithHidCode( int keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetLightingForKeyWithQuartzCode( int keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetLightingForKeyWithKeyName( KeyboardKeys keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSaveLightingForKey( KeyboardKeys keyName );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedRestoreLightingForKey( KeyboardKeys keyName );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedFlashSingleKey( KeyboardKeys keyName, int redPercentage, int greenPercentage, int bluePercentage, int msDuration, int msInterval );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedPulseSingleKey( KeyboardKeys keyName, int startRedPercentage, int startGreenPercentage, int startBluePercentage, int finishRedPercentage, int finishGreenPercentage, int finishBluePercentage, int msDuration, bool isInfinite );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedStopEffectsOnKey( KeyboardKeys keyName );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern bool LogiLedSetLightingForTargetZone( DeviceType deviceType, int zone, int redPercentage, int greenPercentage, int bluePercentage );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        internal static extern void LogiLedShutdown();
    }
}