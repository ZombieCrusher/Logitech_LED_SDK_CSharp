#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    // This is the generic value enum working with most mice but logitech did some mess
    // i.e [ 1 gets invalid and logo with other buttons zone becomes 0 ]
    // So it will be better to set color both zones unless the model is known
    // For Example: G203 mouse has these color zones ( back and logo ) combined
    // so 0 needs to be used to set color as 1 would not work
    public enum TargetZoneMouse : sbyte
    {
        OTHER_SIDE = 0,
        LOGO_SIDE = 1
    }
}