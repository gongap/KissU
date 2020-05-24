using Volo.Abp.Reflection;

namespace KissU.Modules.QuickStart.Authorization
{
    public class QuickStartPermissions
    {
        public const string GroupName = "QuickStart";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(QuickStartPermissions));
        }
    }
}