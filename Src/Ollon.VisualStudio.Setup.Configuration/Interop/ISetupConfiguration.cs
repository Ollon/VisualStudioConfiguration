using System.Runtime.InteropServices;

namespace Ollon.VisualStudio.Interop
{
    /// <summary>
    /// Class <see cref="ISetupConfiguration"/>
    /// </summary>
    [Guid("42843719-DB4C-46C2-8E7C-64F1816EFD5B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISetupConfiguration
    {
        /// <summary>
        /// Gets the enumerator for the instances
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        IEnumSetupInstances EnumInstances();

        /// <summary>
        /// Gets <see cref="ISetupInstance"/>s related to the current process.
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        ISetupInstance GetInstanceForCurrentProcess();

        /// <summary>
        /// Returns an <see cref="ISetupInstance"/> when given its path
        /// </summary>
        /// <param name="path">The path representing the root of the installation</param>
        /// <returns> <see cref="ISetupInstance"/> </returns>
        [return: MarshalAs(UnmanagedType.Interface)]
        ISetupInstance GetInstanceForPath([MarshalAs(UnmanagedType.LPWStr)] [In] string path);
    }
}