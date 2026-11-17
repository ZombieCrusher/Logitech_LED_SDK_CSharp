#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Identifies a lighting zone on a compatible keyboard.
    /// </summary>
    public enum TargetZoneKeyboard : sbyte
    {
        /// <summary>Entire keyboard zone.</summary>
        ENTIRE_KEYBOARD_SIDE = 0,
        /// <summary>Left keyboard zone.</summary>
        LEFT_SIDE = 1,
        /// <summary>Center keyboard zone.</summary>
        CENTRE_SIDE = 2,
        /// <summary>Right keyboard zone.</summary>
        RIGHT_SIDE = 3,
        /// <summary>Arrow keys zone.</summary>
        ARROW_KEYS_SIDE = 4,
        /// <summary>Numeric keypad zone.</summary>
        NUMPAD_KEYS_SIDE = 5
    }
}