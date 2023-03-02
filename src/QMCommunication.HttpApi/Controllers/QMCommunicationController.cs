using QMCommunication.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QMCommunication.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class QMCommunicationController : AbpController
    {
        protected QMCommunicationController()
        {
            LocalizationResource = typeof(QMCommunicationResource);
        }
    }
}