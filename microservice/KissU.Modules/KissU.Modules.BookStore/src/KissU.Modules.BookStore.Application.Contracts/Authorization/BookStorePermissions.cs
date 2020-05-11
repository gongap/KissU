using Volo.Abp.Reflection;

namespace KissU.Modules.BookStore.Authorization
{
    public class BookStorePermissions
    {
        public const string GroupName = "BookStore";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(BookStorePermissions));
        }
    }
}