using System.Runtime.InteropServices;
using System.Text;

namespace LogitechSDK
{
    internal static class LogitechNative
    {
        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedInit();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedInitWithName( string name );

        //Config option functions
        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedGetConfigOptionNumber([MarshalAs(UnmanagedType.LPWStr)] String configPath, ref double defaultNumber);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedGetConfigOptionBool([MarshalAs(UnmanagedType.LPWStr)] String configPath, ref bool defaultRed);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedGetConfigOptionColor([MarshalAs(UnmanagedType.LPWStr)] String configPath, ref int defaultRed, ref int defaultGreen, ref int defaultBlue);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedGetConfigOptionKeyInput([MarshalAs(UnmanagedType.LPWStr)] String configPath, StringBuilder buffer, int bufsize);
        /////////////////////

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetTargetDevice(int targetDevice);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedGetSdkVersion(ref int majorNum, ref int minorNum, ref int buildNum);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSaveCurrentLighting();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetLighting(int redPercentage, int greenPercentage, int bluePercentage);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedRestoreLighting();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedFlashLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedPulseLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedStopEffects();

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedExcludeKeysFromBitmap(KeyboardNames[] keyList, int listCount);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetLightingFromBitmap(byte[] bitmap);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetLightingForKeyWithScanCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetLightingForKeyWithHidCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetLightingForKeyWithQuartzCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetLightingForKeyWithKeyName(KeyboardNames keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSaveLightingForKey(KeyboardNames keyName);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedRestoreLightingForKey(KeyboardNames keyName);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedFlashSingleKey(KeyboardNames keyName, int redPercentage, int greenPercentage, int bluePercentage, int msDuration, int msInterval);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedPulseSingleKey(KeyboardNames keyName, int startRedPercentage, int startGreenPercentage, int startBluePercentage, int finishRedPercentage, int finishGreenPercentage, int finishBluePercentage, int msDuration, bool isInfinite);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedStopEffectsOnKey(KeyboardNames keyName);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern bool LogiLedSetLightingForTargetZone(DeviceType deviceType, int zone, int redPercentage, int greenPercentage, int bluePercentage);

        [ DllImport( "LogitechLedEnginesWrapper.dll", CallingConvention = CallingConvention.Cdecl ) ]
        public static extern void LogiLedShutdown();
    }
}
