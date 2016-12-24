using System.Runtime.InteropServices;

namespace Ollon.VisualStudio.Interop
{
    [Guid("26AAB78C-4A60-49D6-AF3B-3C35BC93365D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISetupConfiguration2 : ISetupConfiguration
    {
        [return: MarshalAs(UnmanagedType.Interface)]
        IEnumSetupInstances EnumAllInstances();
    }
}