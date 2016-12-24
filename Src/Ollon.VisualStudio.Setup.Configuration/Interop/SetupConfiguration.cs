using System.Runtime.InteropServices;

namespace Ollon.VisualStudio.Interop
{
    [Guid("42843719-DB4C-46C2-8E7C-64F1816EFD5B")]
    [CoClass(typeof(SetupConfigurationClass))]
    [TypeLibImportClass(typeof(SetupConfigurationClass))]
    [ComImport]
    public interface SetupConfiguration : ISetupConfiguration2, ISetupConfiguration
    {
    }
}