using System.Runtime.InteropServices;

namespace Ollon.VisualStudio.Interop
{
    /// <summary>
    /// Represents failed or erroneous instance states.
    /// </summary>
    [Guid("46DCCD94-A287-476A-851E-DFBC2FFDBC20")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISetupErrorState
    {
        /// <summary>
        /// Gets the packages that failed to install.
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
        ISetupFailedPackageReference[] GetFailedPackages();

        /// <summary>
        /// Gets packages that were skipped that probably should not have been.
        /// </summary>
        /// <returns></returns>
        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
        ISetupPackageReference[] GetSkippedPackages();
    }
}