using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace QMCommunication.Web
{
    [Dependency(ReplaceServices = true)]
    public class QMCommunicationBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "QMCommunication";
    }
}
