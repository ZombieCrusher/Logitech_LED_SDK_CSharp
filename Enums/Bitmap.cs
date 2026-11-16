#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    public enum Bitmap : ushort
    {
        WIDTH = 21,
        HEIGHT = 6,
        BYTES_PER_KEY = 4,
        SIZE = 504 // WIDTH * HEIGHT * BYTES_PER_KEY
    }
}