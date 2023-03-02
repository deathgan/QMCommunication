using QMCommunication.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QMCommunication.Permissions
{
    public class QMCommunicationPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(QMCommunicationPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(QMCommunicationPermissions.MyPermission1, L("Permission:MyPermission1"));

            var palabelCasecodePermission = myGroup.AddPermission(QMCommunicationPermissions.PalabelCasecode.Default, L("Permission:PalabelCasecode"));
            palabelCasecodePermission.AddChild(QMCommunicationPermissions.PalabelCasecode.Create, L("Permission:Create"));
            palabelCasecodePermission.AddChild(QMCommunicationPermissions.PalabelCasecode.Update, L("Permission:Update"));
            palabelCasecodePermission.AddChild(QMCommunicationPermissions.PalabelCasecode.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<QMCommunicationResource>(name);
        }
    }
}
