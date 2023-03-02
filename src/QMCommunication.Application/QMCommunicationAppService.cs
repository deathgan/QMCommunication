using System;
using System.Collections.Generic;
using System.Text;
using QMCommunication.Localization;
using Volo.Abp.Application.Services;

namespace QMCommunication
{
    /* Inherit your application services from this class.
     */
    public abstract class QMCommunicationAppService : ApplicationService
    {
        protected QMCommunicationAppService()
        {
            LocalizationResource = typeof(QMCommunicationResource);
        }
    }
}
