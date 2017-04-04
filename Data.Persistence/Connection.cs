using System.Configuration;

namespace Data.Persistence
{
    static class Connection
    {
        private const string Sql = "name=MyContextSql";
        private const string MySql = "name=MyContextMySql";

        internal static string Connected()
        {
            var provider = ConfigurationManager.AppSettings.Get("DataProvider");

            switch (provider.ToLower())
            {
                case "sql": return Sql;
                case "mysql": return MySql;
                default:
                    return "";
            }
        }

        internal static string Connected(EnumDataProvider dataProvider)
        {
            switch (dataProvider)
            {
                case EnumDataProvider.Sql: return Sql;
                case EnumDataProvider.MySql: return MySql;
                default:
                    return "";
            }
        }
    }
}
