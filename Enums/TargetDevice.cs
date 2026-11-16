#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    [ Flags ]
    public enum TargetDevice : sbyte
    {
        MONOCHROME = 1 << 0,
        RGB = 1 << 1,
        PERKEY_RGB = 1 << 2,
        ALL = ( MONOCHROME | RGB | PERKEY_RGB )
    }
}