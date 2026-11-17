#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Identifies a generic lighting zone on a compatible mouse.
    /// </summary>
    /// <remarks>Mouse zone availability and mapping vary by model; some models combine zones or do not support every value.</remarks>
    public enum TargetZoneMouse : sbyte
    {
        /// <summary>Generic non-logo or combined mouse lighting zone.</summary>
        OTHER_SIDE = 0,
        /// <summary>Mouse logo zone when supported by the model.</summary>
        LOGO_SIDE = 1
    }
}