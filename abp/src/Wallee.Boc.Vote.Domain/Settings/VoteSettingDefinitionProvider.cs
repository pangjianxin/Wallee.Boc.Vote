using Volo.Abp.Settings;

namespace Wallee.Boc.Vote.Settings;

public class VoteSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(VoteSettings.MySetting1));
    }
}
