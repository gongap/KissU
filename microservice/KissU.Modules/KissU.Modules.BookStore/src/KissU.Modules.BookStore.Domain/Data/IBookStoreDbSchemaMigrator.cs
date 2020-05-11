using System.Threading.Tasks;

namespace KissU.Modules.BookStore.Data
{
    public interface IBookStoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
