using System.Drawing;
using System.Text;

namespace LogitechSDK
{
    /// <summary>
    /// Provides managed access to the Logitech LED SDK.
    /// </summary>
    public static class Logitech
    {
        /// <summary>
        /// Initializes the Logitech LED SDK.
        /// </summary>
        /// <returns><see langword="true"/> if initialization succeeds; otherwise, <see langword="false"/>.</returns>
        public static bool InitialiseAPI()
        {
            return LogitechNative.LogiLedInit();
        }

        /// <summary>
        /// Initializes the Logitech LED SDK with a name for this integration.
        /// </summary>
        /// <param name="Name">The integration name shown by Logitech software.</param>
        /// <returns><see langword="true"/> if initialization succeeds; otherwise, <see langword="false"/>.</returns>
        public static bool InitialiseAPI( string Name )
        {
            return LogitechNative.LogiLedInitWithName( Name );
        }

        /// <summary>
        /// Shuts down the Logitech LED SDK and releases its native resources.
        /// </summary>
        public static void Shutdown()
        {
            LogitechNative.LogiLedShutdown();
        }

        /// <summary>
        /// Gets the numeric value of a Logitech SDK configuration option.
        /// </summary>
        /// <param name="Configpath">The path identifying the configuration option.</param>
        /// <param name="OptionNumber">Receives the configured value or its default value.</param>
        /// <returns><see langword="true"/> if the value is retrieved; otherwise, <see langword="false"/>.</returns>
        public static bool GetConfigOptionNumber( string Configpath, out double OptionNumber )
        {
            return LogitechNative.LogiLedGetConfigOptionNumber( Configpath, out OptionNumber );
        }

        /// <summary>
        /// Gets the Boolean value of a Logitech SDK configuration option.
        /// </summary>
        /// <param name="Configpath">The path identifying the configuration option.</param>
        /// <param name="OptionBool">Receives the configured value or its default value.</param>
        /// <returns><see langword="true"/> if the value is retrieved; otherwise, <see langword="false"/>.</returns>
        public static bool GetConfigOptionBool( string Configpath, out bool OptionBool )
        {
            return LogitechNative.LogiLedGetConfigOptionBool( Configpath, out OptionBool );
        }

        /// <summary>
        /// Gets the color value of a Logitech SDK configuration option.
        /// </summary>
        /// <param name="Configpath">The path identifying the configuration option.</param>
        /// <param name="RecievedColor">Receives the configured color or its default color.</param>
        /// <returns><see langword="true"/> if the value is retrieved; otherwise, <see langword="false"/>.</returns>
        public static bool GetConfigOptionColor( string Configpath, out Color RecievedColor )
        {
            bool b = LogitechNative.LogiLedGetConfigOptionColor( Configpath, out int Red, out int Green, out int Blue );
            RecievedColor = Color.FromArgb( Red, Green, Blue );
            return b;
        }

        /// <summary>
        /// Queries a key-input configuration option.
        /// </summary>
        /// <param name="Configpath">The path identifying the configuration option.</param>
        /// <returns><see langword="true"/> if the native query succeeds; otherwise, <see langword="false"/>.</returns>
        /// <remarks>The current wrapper does not expose the key-input value, only the query result.</remarks>
        public static bool LogiLedGetConfigOptionKeyInput( string Configpath )
        {
            StringBuilder sb = new();
            return LogitechNative.LogiLedGetConfigOptionKeyInput( Configpath, sb, sb.Capacity );
        }

        /// <summary>
        /// Sets the device categories affected by subsequent lighting operations.
        /// </summary>
        /// <param name="Device">A <see cref="TargetDevice"/> value or combination of values.</param>
        /// <remarks>The native success result is not exposed by this method. If not set, the native SDK targets all device categories.</remarks>
        public static void SetLEDTargetDevice( TargetDevice Device )
        {
            LogitechNative.LogiLedSetTargetDevice( ( int ) Device );
        }

        /// <summary>
        /// Gets the installed Logitech LED SDK version.
        /// </summary>
        /// <returns>The version formatted as <c>major.minor.build</c>.</returns>
        /// <remarks>The native version query's success result is not exposed by this method.</remarks>
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

        /// <summary>
        /// Saves the current lighting state for the targeted devices.
        /// </summary>
        /// <returns><see langword="true"/> if the state is saved; otherwise, <see langword="false"/>.</returns>
        public static bool SaveLEDCurrentLighting()
        {
            return LogitechNative.LogiLedSaveCurrentLighting();
        }

        /// <summary>
        /// Sets the lighting color for the targeted devices.
        /// </summary>
        /// <param name="StartColor">The color to apply. RGB channels are converted to the native SDK's 0–100 percentage range.</param>
        /// <returns><see langword="true"/> if the lighting is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLighting( Color StartColor )
        {
            return LogitechNative.LogiLedSetLighting( ClampColorValueToPercentage( StartColor.R ), ClampColorValueToPercentage( StartColor.G ), ClampColorValueToPercentage( StartColor.B ) );
        }

        /// <summary>
        /// Restores the lighting state previously saved for the targeted devices.
        /// </summary>
        /// <returns><see langword="true"/> if the state is restored; otherwise, <see langword="false"/>.</returns>
        public static bool RestoreLEDLighting() 
        {
            return LogitechNative.LogiLedRestoreLighting();
        }

        /// <summary>
        /// Flashes the targeted devices between the specified color and black.
        /// </summary>
        /// <param name="NewColor">The active flash color.</param>
        /// <param name="msDuration">The effect duration in milliseconds; zero requests an infinite duration.</param>
        /// <param name="msInterval">The flash interval in milliseconds.</param>
        /// <returns><see langword="true"/> if the effect starts; otherwise, <see langword="false"/>.</returns>
        public static bool FlashLEDLighting( Color NewColor, int msDuration, int msInterval )
        {
            return LogitechNative.LogiLedFlashLighting( ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ), msDuration, msInterval );
        }

        /// <summary>
        /// Pulses the targeted devices using the specified color.
        /// </summary>
        /// <param name="NewColor">The color used by the pulse effect.</param>
        /// <param name="msDuration">The effect duration in milliseconds; zero requests an infinite duration.</param>
        /// <param name="msInterval">The pulse interval in milliseconds.</param>
        /// <returns><see langword="true"/> if the effect starts; otherwise, <see langword="false"/>.</returns>
        public static bool PulseLEDLighting( Color NewColor, int msDuration, int msInterval )
        {
            return LogitechNative.LogiLedPulseLighting( ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ), msDuration, msInterval );
        }

        /// <summary>
        /// Stops general lighting effects on the targeted devices.
        /// </summary>
        /// <returns><see langword="true"/> if the effects are stopped; otherwise, <see langword="false"/>.</returns>
        public static bool StopLEDEffects()
        {
            return LogitechNative.LogiLedStopEffects();
        }

        /// <summary>
        /// Excludes keyboard keys from subsequent bitmap lighting updates.
        /// </summary>
        /// <param name="Keys">The keys to exclude from bitmap updates.</param>
        /// <returns><see langword="true"/> if the exclusions are set; otherwise, <see langword="false"/>.</returns>
        public unsafe static bool ExcludeLEDKeysFromBitmap( KeyboardKeys[] Keys )
        {
            fixed( KeyboardKeys* KeysPtr = Keys )
            {
                return LogitechNative.LogiLedExcludeKeysFromBitmap( ( int* )KeysPtr, Keys.Length );
            }
        }

        /// <summary>
        /// Applies lighting from a 21-by-6 keyboard bitmap.
        /// </summary>
        /// <param name="bytes">The bitmap data, containing four RGBA bytes for each grid position.</param>
        /// <returns><see langword="true"/> if the bitmap is applied; otherwise, <see langword="false"/>.</returns>
        /// <remarks>Provide <see cref="Bitmap.SIZE"/> bytes. An alpha value of zero leaves the corresponding key unchanged.</remarks>
        public unsafe static bool SetLEDLightingFromBitmap( byte[] bytes ) 
        {
            fixed( byte* bitmapPtr = bytes )
            {
                return LogitechNative.LogiLedSetLightingFromBitmap( bitmapPtr );
            }
        }

        /// <summary>
        /// Sets a keyboard key's color using a platform scan code.
        /// </summary>
        /// <param name="KeyCode">The key's scan code.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightingForKeyWithScanCode( int KeyCode, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithScanCode( KeyCode, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Sets a keyboard key's color using a HID code.
        /// </summary>
        /// <param name="KeyCode">The key's HID code.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightingForKeyWithHIDCode( int KeyCode, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithHidCode( KeyCode, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Sets a keyboard key's color using a Quartz code.
        /// </summary>
        /// <param name="KeyCode">The key's Quartz code.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightingForKeyWithQuartzCode( int KeyCode, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithQuartzCode( KeyCode, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Sets the color of a keyboard key identified by its Logitech key name.
        /// </summary>
        /// <param name="Key">The key to change.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightOfKeyboardKey( KeyboardKeys Key, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForKeyWithKeyName( Key, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Saves the current lighting color of a keyboard key.
        /// </summary>
        /// <param name="Key">The key whose color to save.</param>
        /// <returns><see langword="true"/> if the color is saved; otherwise, <see langword="false"/>.</returns>
        public static bool SaveLEDLightingForKey( KeyboardKeys Key )
        {
            return LogitechNative.LogiLedSaveLightingForKey( Key );
        }

        /// <summary>
        /// Restores the saved lighting color of a keyboard key.
        /// </summary>
        /// <param name="Key">The key whose saved color to restore.</param>
        /// <returns><see langword="true"/> if the color is restored; otherwise, <see langword="false"/>.</returns>
        public static bool RestoreLEDLightingForKey( KeyboardKeys Key )
        {
            return LogitechNative.LogiLedRestoreLightingForKey( Key );
        }

        /// <summary>
        /// Flashes one keyboard key between the specified color and black.
        /// </summary>
        /// <param name="Key">The key to flash.</param>
        /// <param name="StartColor">The active flash color.</param>
        /// <param name="msDuration">The effect duration in milliseconds; zero requests an infinite duration.</param>
        /// <param name="msInterval">The flash interval in milliseconds.</param>
        /// <returns><see langword="true"/> if the effect starts; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDFlashSingleKey( KeyboardKeys Key, Color StartColor, int msDuration, int msInterval )
        {
            return LogitechNative.LogiLedFlashSingleKey( Key, ClampColorValueToPercentage( StartColor.R ), ClampColorValueToPercentage( StartColor.G ), ClampColorValueToPercentage( StartColor.B ), msDuration, msInterval );
        }

        /// <summary>
        /// Pulses one keyboard key between two colors.
        /// </summary>
        /// <param name="Key">The key to pulse.</param>
        /// <param name="StartColor">The starting color.</param>
        /// <param name="EndColor">The ending color.</param>
        /// <param name="msDuration">The effect duration in milliseconds.</param>
        /// <param name="isInfinite"><see langword="true"/> to repeat the effect indefinitely.</param>
        /// <returns><see langword="true"/> if the effect starts; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDPulseSingleKey(KeyboardKeys Key, Color StartColor, Color EndColor, int msDuration, bool isInfinite)
        {
            return LogitechNative.LogiLedPulseSingleKey(Key, ClampColorValueToPercentage(StartColor.R), ClampColorValueToPercentage(StartColor.G), ClampColorValueToPercentage(StartColor.B), ClampColorValueToPercentage(EndColor.R), ClampColorValueToPercentage(EndColor.G), ClampColorValueToPercentage(EndColor.B), msDuration, isInfinite);
        }

        /// <summary>
        /// Stops a lighting effect running on one keyboard key.
        /// </summary>
        /// <param name="Key">The key whose effect to stop.</param>
        /// <returns><see langword="true"/> if the effect is stopped; otherwise, <see langword="false"/>.</returns>
        public static bool StopLEDEffectsOnKey( KeyboardKeys Key )
        {
            return LogitechNative.LogiLedStopEffectsOnKey( Key );
        }

        /// <summary>
        /// Sets a headset lighting zone to the specified color.
        /// </summary>
        /// <param name="Zone">The headset zone to change.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightForTargetZoneForHeadset( TargetZoneHeadset Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.HEADSET, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Sets a keyboard lighting zone to the specified color.
        /// </summary>
        /// <param name="Zone">The keyboard zone to change.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightForTargetZoneForKeyboard( TargetZoneKeyboard Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.KEYBOARD, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Sets a mouse lighting zone to the specified color.
        /// </summary>
        /// <param name="Zone">The mouse zone to change.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightForTargetZoneForMouse( TargetZoneMouse Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.MOUSE, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Sets a mouse mat lighting zone to the specified color.
        /// </summary>
        /// <param name="Zone">The mouse mat zone to change.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightForTargetZoneForMouseMat( TargetZoneMouseMat Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.MOUSE_MAT, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        /// <summary>
        /// Sets a speaker lighting zone to the specified color.
        /// </summary>
        /// <param name="Zone">The speaker zone to change.</param>
        /// <param name="NewColor">The color to apply.</param>
        /// <returns><see langword="true"/> if the color is set; otherwise, <see langword="false"/>.</returns>
        public static bool SetLEDLightForTargetZoneForSpeaker( TargetZoneSpeaker Zone, Color NewColor )
        {
            return LogitechNative.LogiLedSetLightingForTargetZone( DeviceType.SPEAKER, (byte)Zone, ClampColorValueToPercentage( NewColor.R ), ClampColorValueToPercentage( NewColor.G ), ClampColorValueToPercentage( NewColor.B ) );
        }

        private static sbyte ClampColorValueToPercentage( float Value )
        {
            return (sbyte)Math.Clamp( ( Value / 255 ) * 100, 0f, 100f );
        }
    }
}