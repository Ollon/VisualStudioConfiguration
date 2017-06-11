


using Microsoft.VisualStudio.Setup.Configuration;

public class SetupPackageReference
{
    private ISetupPackageReference _reference;

    private SetupPackageReference(ISetupPackageReference reference)
    {
        _reference = reference;
    }

    public static SetupPackageReference From(ISetupPackageReference reference)
    {
        return new SetupPackageReference(reference);
    }

    public string Id => _reference.GetId();
    public string Version => _reference.GetVersion();
    public string Chip => _reference.GetChip();
    public string Language => _reference.GetLanguage();
    public string Branch => _reference.GetBranch();
    public string Type => _reference.GetType();
    public string UniqueId => _reference.GetUniqueId();
    public bool IsExtension => _reference.GetIsExtension();
}
