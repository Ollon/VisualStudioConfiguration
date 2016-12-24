using System.Runtime.InteropServices;

namespace Ollon.VisualStudio.Interop
{
    /// <summary>
    /// Helper interface for parsing version information.
    /// </summary>
    [Guid("42B21B78-6192-463E-87BF-D577838F1D5C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISetupHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        ulong ParseVersion([MarshalAs(UnmanagedType.LPWStr)] [In] string version);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="versionRange"></param>
        /// <param name="minVersion"></param>
        /// <param name="maxVersion"></param>
        void ParseVersionRange(
            [MarshalAs(UnmanagedType.LPWStr)] [In] string versionRange, 
            [MarshalAs(UnmanagedType.U8)] out ulong minVersion, 
            [MarshalAs(UnmanagedType.U8)] out ulong maxVersion);
    }
}