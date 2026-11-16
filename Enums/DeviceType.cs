#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    public enum DeviceType : sbyte
    {
        KEYBOARD = 0x0,
        MOUSE = 0x3,
        MOUSE_MAT = 0x4,
        HEADSET = 0x8,
        SPEAKER = 0xE
    }
}