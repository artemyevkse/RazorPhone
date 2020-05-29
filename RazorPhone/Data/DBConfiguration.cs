using LinqToDB;
using LinqToDB.Configuration;
using System.Collections.Generic;
using System.Linq;
using RazorPhone.Data.Models;

namespace RazorPhone.Data
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }


    public class DBConfiguration : ILinqToDBSettings
    {
        public const string DB_NAME = "WebMobile";
        public const string PROVIDER_NAME = "SqlServer";

        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();
        public string DefaultConfiguration => PROVIDER_NAME;
        public string DefaultDataProvider => PROVIDER_NAME;

        protected string _connectionString;


        public DBConfiguration(string connectionString) { _connectionString = connectionString; }

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return new ConnectionStringSettings { Name = DB_NAME, ProviderName = PROVIDER_NAME,
                    ConnectionString = _connectionString
                };
            }
        }
    }


    public class DbWebMobile : LinqToDB.Data.DataConnection
    {
        public DbWebMobile() : base(DBConfiguration.DB_NAME) { }

        public ITable<Phone> Phone => GetTable<Phone>();
        public ITable<User> User => GetTable<User>();
    }
}