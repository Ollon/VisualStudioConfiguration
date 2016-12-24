using System.Runtime.InteropServices;

namespace Ollon.VisualStudio.Interop
{
    /// <summary>
    /// Represents an <see cref="ISetupPackageReference"/> that failed.
    /// </summary>
    [Guid("E73559CD-7003-4022-B134-27DC650B280F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISetupFailedPackageReference : ISetupPackageReference
    {

    }
}