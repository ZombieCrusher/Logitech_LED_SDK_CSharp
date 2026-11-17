#pragma warning disable IDE0130 //  Namespace is not matching with folder structure something
namespace LogitechSDK
#pragma warning restore IDE0130
{
    /// <summary>
    /// Describes the dimensions and data size of the native keyboard bitmap.
    /// </summary>
    public enum Bitmap : ushort
    {
        /// <summary>Bitmap width in positions.</summary>
        WIDTH = 21,
        /// <summary>Bitmap height in positions.</summary>
        HEIGHT = 6,
        /// <summary>Number of bytes used for each position.</summary>
        BYTES_PER_KEY = 4,
        /// <summary>Total bitmap size in bytes.</summary>
        SIZE = 504 // WIDTH * HEIGHT * BYTES_PER_KEY
    }
}