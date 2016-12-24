using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System;

namespace Ollon.VisualStudio.Interop
{
    [Guid("89143C9A-05AF-49B0-B717-72E218A2185C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISetupInstance2 : ISetupInstance
    {
        [return: MarshalAs(UnmanagedType.BStr)]
        string GetInstanceId();

        [return: MarshalAs(UnmanagedType.Struct)]
        System.Runtime.InteropServices.ComTypes.FILETIME GetInstallDate();

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetInstallationName();

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetInstallationPath();

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetInstallationVersion();

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetDisplayName([MarshalAs(UnmanagedType.U4)] [In] int lcid = 0);

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetDescription([MarshalAs(UnmanagedType.U4)] [In] int lcid = 0);

        [return: MarshalAs(UnmanagedType.BStr)]
        string ResolvePath([MarshalAs(UnmanagedType.LPWStr)] [In] string pwszRelativePath = null);

        [return: MarshalAs(UnmanagedType.U4)]
        InstanceState GetState();

        [return: MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_UNKNOWN)]
        ISetupPackageReference[] GetPackages();

        ISetupPackageReference GetProduct();

        [return: MarshalAs(UnmanagedType.BStr)]
        string GetProductPath();

        ISetupErrorState GetErrors();
    }
}