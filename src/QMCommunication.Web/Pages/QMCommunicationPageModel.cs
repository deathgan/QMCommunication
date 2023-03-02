using QMCommunication.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace QMCommunication.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class QMCommunicationPageModel : AbpPageModel
    {
        protected QMCommunicationPageModel()
        {
            LocalizationResourceType = typeof(QMCommunicationResource);
        }
    }
}