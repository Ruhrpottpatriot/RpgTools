namespace RpgTools.Main.ViewModels
{
    using System.ComponentModel.Composition;

    using RpgTools.Core.Contracts;

    [RpgModuleMetadata(Name = "ModuleB")]
    [Export(typeof(IRpgModuleContract))]
    public class ModuleBViewModel : IRpgModuleContract
    {
        
    }
}