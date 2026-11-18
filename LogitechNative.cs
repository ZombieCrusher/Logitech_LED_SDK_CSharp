using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace LogitechSDK
{
    internal static partial class LogitechNative
    {
        // Initialisation

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedInit();

        [ LibraryImport( "LogitechLedEnginesWrapper.dll", StringMarshalling = StringMarshalling.Utf16 ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedInitWithName( string name );

        [LibraryImport("LogitechLedEnginesWrapper.dll")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static partial bool LogiLedGetSdkVersion(out int majorNum, out int minorNum, out int buildNum);

        [LibraryImport("LogitechLedEnginesWrapper.dll")]
        [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
        internal static partial void LogiLedShutdown();

        // ConfigOptions

        [LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedGetConfigOptionNumber( [ MarshalAs( UnmanagedType.LPWStr ) ] string configPath, out double defaultNumber );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedGetConfigOptionBool( [ MarshalAs( UnmanagedType.LPWStr )  ] string configPath, [ MarshalAs( UnmanagedType.I1 ) ] out bool defaultRed );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll", StringMarshalling = StringMarshalling.Utf16 ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedGetConfigOptionColor( [ MarshalAs( UnmanagedType.LPWStr ) ] string configPath, out int defaultRed, out int defaultGreen, out int defaultBlue );

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode ) ]
        internal static extern bool LogiLedGetConfigOptionKeyInput( [ MarshalAs( UnmanagedType.LPWStr ) ] string configPath, StringBuilder buffer, int bufsize );

        // Generic functions, applies to all

        [LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSetTargetDevice( int targetDevice );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSaveCurrentLighting();

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSetLighting( int redPercentage, int greenPercentage, int bluePercentage );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedRestoreLighting();

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedFlashLighting( int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedPulseLighting( int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedStopEffects();

        // Per - key functions, apply to LOGI_DEVICETYPE_PERKEY_RGB devices.

        [LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static unsafe partial bool LogiLedExcludeKeysFromBitmap( int* keyList, int listCount );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static unsafe partial bool LogiLedSetLightingFromBitmap( byte* bitmap );

        [LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSetLightingForKeyWithScanCode( int keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSetLightingForKeyWithHidCode( int keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSetLightingForKeyWithQuartzCode( int keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSetLightingForKeyWithKeyName( KeyboardKeys keyCode, int redPercentage, int greenPercentage, int bluePercentage );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSaveLightingForKey( KeyboardKeys keyName );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedRestoreLightingForKey( KeyboardKeys keyName );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedFlashSingleKey( KeyboardKeys keyName, int redPercentage, int greenPercentage, int bluePercentage, int msDuration, int msInterval );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedPulseSingleKey( KeyboardKeys keyName, int startRedPercentage, int startGreenPercentage, int startBluePercentage, int finishRedPercentage, int finishGreenPercentage, int finishBluePercentage, int msDuration, [MarshalAs(UnmanagedType.Bool)] bool isInfinite );

        [ LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [ typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedStopEffectsOnKey( KeyboardKeys keyName );

        // Zone functions, apply to devices with zones.

        [LibraryImport( "LogitechLedEnginesWrapper.dll" ) ]
        [ UnmanagedCallConv( CallConvs = [typeof( CallConvCdecl ) ] ) ]
        [ return: MarshalAs( UnmanagedType.I1 ) ]
        internal static partial bool LogiLedSetLightingForTargetZone( DeviceType deviceType, int zone, int redPercentage, int greenPercentage, int bluePercentage );
    }
}