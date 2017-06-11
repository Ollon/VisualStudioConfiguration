using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.VisualStudio.Setup.Configuration;

public class SetupInstance
{
    private ISetupInstance2 _instance;

    public static SetupInstance From(ISetupInstance2 instance)
    {
        return new SetupInstance(instance);
    }

    private SetupInstance(ISetupInstance2 instance)
    {
        _instance = instance;
    }
    public string InstanceId => _instance.GetInstanceId();
    public InstanceState State => _instance.GetState();
    public string ProductPath => _instance.GetProductPath();
    public string Description => _instance.GetDescription();
    public string DisplayName => _instance.GetDisplayName();
    public string InstallationVersion => _instance.GetInstallationVersion();
    public string InstallationPath => _instance.GetInstallationPath();
    public string InstallationName => _instance.GetInstallationName();
    public SetupPackageReference Product => SetupPackageReference.From(_instance.GetProduct());
    public IEnumerable<SetupPackageReference> Packages => from p in _instance.GetPackages()
                                                          where string.Equals(p.GetType(), "Workload", StringComparison.OrdinalIgnoreCase)
                                                          select SetupPackageReference.From(p);

    public ISetupInstance2 AsInterface() => _instance;
}