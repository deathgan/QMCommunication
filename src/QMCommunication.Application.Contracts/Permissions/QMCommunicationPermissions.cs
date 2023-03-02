namespace QMCommunication.Permissions
{
    public static class QMCommunicationPermissions
    {
        public const string GroupName = "QMCommunication";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class PalabelCasecode
        {
            public const string Default = GroupName + ".PalabelCasecode";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
