using System;
using System.Collections.Generic;
using System.Text;

namespace LogitechSDK
{
    public static class Logitech
    {
        private const int LOGITECH_DEVICETYPE_MONOCHROME_ORD = 0;
        private const int LOGITECH_DEVICETYPE_RGB_ORD = 1;
        private const int LOGITECH_DEVICETYPE_PERKEY_RGB_ORD = 2;

        public const int LOGITECH_DEVICETYPE_MONOCHROME = ( 1 << LOGITECH_DEVICETYPE_MONOCHROME_ORD );
        public const int LOGITECH_DEVICETYPE_RGB = ( 1 << LOGITECH_DEVICETYPE_RGB_ORD );
        public const int LOGITECH_DEVICETYPE_PERKEY_RGB = ( 1 << LOGITECH_DEVICETYPE_PERKEY_RGB_ORD );
        public const int LOGITECH_DEVICETYPE_ALL = ( LOGITECH_DEVICETYPE_MONOCHROME | LOGITECH_DEVICETYPE_RGB | LOGITECH_DEVICETYPE_PERKEY_RGB );

        public const int LOGITECH_LED_BITMAP_WIDTH = 21;
        public const int LOGITECH_LED_BITMAP_HEIGHT = 6;
        public const int LOGITECH_LED_BITMAP_BYTES_PER_KEY = 4;

        public const int LOGITECH_LED_BITMAP_SIZE = LOGITECH_LED_BITMAP_WIDTH * LOGITECH_LED_BITMAP_HEIGHT * LOGITECH_LED_BITMAP_BYTES_PER_KEY;
        public const int LOGITECH_LED_DURATION_INFINITE = 0;

        public static bool Init()
        {
            return LogitechNative.LogiLedInit();
        }

        public static void Shutdown()
        {
            LogitechNative.LogiLedShutdown();
        }
    }
}
