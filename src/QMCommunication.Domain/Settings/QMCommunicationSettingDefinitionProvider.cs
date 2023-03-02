using Volo.Abp.Settings;

namespace QMCommunication.Settings
{
    public class QMCommunicationSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(QMCommunicationSettings.MySetting1));
        }
    }
}
