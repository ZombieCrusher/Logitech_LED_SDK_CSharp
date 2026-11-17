#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Identifies a lighting zone on a compatible speaker.
    /// </summary>
    public enum TargetZoneSpeaker : sbyte
    {
        /// <summary>Front-left speaker zone.</summary>
        FRONT_LEFT_SIDE = 0,
        /// <summary>Front-right speaker zone.</summary>
        FRONT_RIGHT_SIDE = 1,
        /// <summary>Rear-left speaker zone.</summary>
        REAR_LEFT_SIDE = 2,
        /// <summary>Rear-right speaker zone.</summary>
        REAR_RIGHT_SIDE = 3,
    }
}