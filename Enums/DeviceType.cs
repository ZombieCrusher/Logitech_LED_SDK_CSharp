#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Identifies a device family when setting lighting by zone.
    /// </summary>
    public enum DeviceType : sbyte
    {
        /// <summary>Keyboard device.</summary>
        KEYBOARD = 0x0,
        /// <summary>Mouse device.</summary>
        MOUSE = 0x3,
        /// <summary>Mouse mat device.</summary>
        MOUSE_MAT = 0x4,
        /// <summary>Headset device.</summary>
        HEADSET = 0x8,
        /// <summary>Speaker device.</summary>
        SPEAKER = 0xE
    }
}