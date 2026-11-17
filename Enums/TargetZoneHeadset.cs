#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Identifies a lighting zone on a compatible headset.
    /// </summary>
    public enum TargetZoneHeadset : sbyte
    {
        /// <summary>Headset logo zone.</summary>
        LOGO_SIDE = 0,
        /// <summary>Back-side headset zone.</summary>
        BACK_SIDE = 1
    }
}