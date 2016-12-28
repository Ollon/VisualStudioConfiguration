using Ollon.VisualStudio.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// 
/// </summary>
public static class SetupEnvironment
{
    private const int REGDB_E_CLASSNOTREG = unchecked((int)0x80040154);

    public static SetupInstance GetSetupInstance()
    {
        SetupInstance instance = null;
#pragma warning disable CS0219 // Variable is assigned but its value is never used
        int exHResult = 0;
#pragma warning restore CS0219 // Variable is assigned but its value is never used
        ISetupConfiguration2 configuration = SetupEnvironment.GetQuery();

        IEnumSetupInstances enumerator = configuration.EnumAllInstances();

        int fetched;
        ISetupInstance[] instances = new ISetupInstance[1];
        do
        {
            enumerator.Next(1, instances, out fetched);
            if (fetched > 0)
            {
                instance = SetupInstance.From((ISetupInstance2)instances[0]);
                break;
            }
        }
        while (fetched > 0);
        {
            exHResult = 0;

        }

        return instance;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static ISetupConfiguration2 GetQuery()
    {
        try
        {
            SetupConfiguration config = new SetupConfiguration();
            // Try to CoCreate the class object.
            return config;
        }
        catch (COMException ex) when (ex.HResult == REGDB_E_CLASSNOTREG)
        {
            // Try to get the class object using app-local call.
            int result = GetSetupConfiguration(out var query, IntPtr.Zero);

            if (result < 0)
            {
                throw new COMException("Failed to get query", result);
            }

            return (ISetupConfiguration2)query;
        }
    }

    [DllImport("Microsoft.VisualStudio.Setup.Configuration.Native.dll", ExactSpelling = true, PreserveSig = true)]
    private static extern int GetSetupConfiguration(
        [MarshalAs(UnmanagedType.Interface), Out] out ISetupConfiguration configuration,
        IntPtr reserved);
}
