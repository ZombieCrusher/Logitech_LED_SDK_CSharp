using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LogitechSDK
{
    public static class Logitech
    {
        // private const int LOGITECH_DEVICETYPE_MONOCHROME_ORD = 0;
        // private const int LOGITECH_DEVICETYPE_RGB_ORD = 1;
        // private const int LOGITECH_DEVICETYPE_PERKEY_RGB_ORD = 2;

        // public const int LOGITECH_DEVICETYPE_MONOCHROME = ( 1 << LOGITECH_DEVICETYPE_MONOCHROME_ORD );
        // public const int LOGITECH_DEVICETYPE_RGB = ( 1 << LOGITECH_DEVICETYPE_RGB_ORD );
        // public const int LOGITECH_DEVICETYPE_PERKEY_RGB = ( 1 << LOGITECH_DEVICETYPE_PERKEY_RGB_ORD );
        // public const int LOGITECH_DEVICETYPE_ALL = ( LOGITECH_DEVICETYPE_MONOCHROME | LOGITECH_DEVICETYPE_RGB | LOGITECH_DEVICETYPE_PERKEY_RGB );

        // public const int LOGITECH_LED_BITMAP_WIDTH = 21;
        // public const int LOGITECH_LED_BITMAP_HEIGHT = 6;
        // public const int LOGITECH_LED_BITMAP_BYTES_PER_KEY = 4;

        // public const int LOGITECH_LED_BITMAP_SIZE = LOGITECH_LED_BITMAP_WIDTH * LOGITECH_LED_BITMAP_HEIGHT * LOGITECH_LED_BITMAP_BYTES_PER_KEY;
        public const int CONST_LED_DURATION_INFINITE = 0;

        private static bool _isInitialised = false;

        public static bool Init()
        {
            if( _isInitialised )
            {
                return true;
            }

            _isInitialised = LogitechNative.LogiLedInit();
            return _isInitialised;
        }

        public static void Shutdown()
        {
            if( !_isInitialised)
            {
                return;
            }

            LogitechNative.LogiLedShutdown();
        }

        public static void SetLEDTargetDevice( TargetDevice Device )
        {
            LogitechNative.LogiLedSetTargetDevice( ( int ) Device );
        }

        public static void SetLEDLight( Color NewColor )
        {
            LogitechNative.LogiLedSetLighting( ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static void SetLEDLightOfKeyboardKey( KeyboardKeys Key, Color NewColor )
        {
            LogitechNative.LogiLedSetLightingForKeyWithKeyName( Key, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        public static void SetLEDLightForTargetZone( DeviceType Device, TargetZoneHeadset Zone, Color NewColor )
        {
            LogitechNative.LogiLedSetLightingForTargetZone( Device, ( byte )Zone, 100, 0, 0);
        }

        private static byte ClampColorValueToPercentage( float Value )
        {
            return ( byte )Math.Clamp( ( Value / 255) * 100, 0f, 100f );
        }
    }
}
