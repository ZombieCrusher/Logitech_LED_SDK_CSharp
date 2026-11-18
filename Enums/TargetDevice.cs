#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Specifies the categories of devices affected by lighting operations.
    /// </summary>
    /// <remarks>This is a flags enum; combine values with the bitwise OR operator.</remarks>
    [ Flags ]
    public enum TargetDevice : sbyte
    {
        /// <summary>Monochrome-backlit devices.</summary>
        MONOCHROME = 1 << 0,
        /// <summary>RGB devices with non-per-key lighting.</summary>
        RGB = 1 << 1,
        /// <summary>Devices with individually addressable RGB keys.</summary>
        PERKEY_RGB = 1 << 2,
        /// <summary>All supported device categories.</summary>
        ALL =  MONOCHROME | RGB | PERKEY_RGB 
    }
}