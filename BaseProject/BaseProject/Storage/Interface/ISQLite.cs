using SQLite;

namespace BaseProject.Storage.Interface
{
    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
