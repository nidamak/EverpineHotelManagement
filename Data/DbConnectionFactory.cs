using Microsoft.Data.Sqlite;

namespace EverpineHotelManagement.Data
{
    public static class DbConnectionFactory
    {
        public static SqliteConnection Create()
        {
            return new SqliteConnection(AppConfig.ConnectionString);
        }
    }
}