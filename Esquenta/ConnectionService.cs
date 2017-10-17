using Esquenta.Entities;
using Esquenta.Entities.Interfaces;
using Esquenta.Repository;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Esquenta
{
    public class ConnectionService
    {
        private static ConnectionService instance = null;

        private ISessionFactory sessionFactory = CreateSessionFactory();
        private const string DbFile = @"C:\Users\leandro\Desktop\DEV\esquenta.db";
        //private const string DbFile = @"esquenta.db";

        public ConnectionService()
        {
            CreateSessionFactory();

            instance = this;
        }

        public static ConnectionService GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnectionService();
            }

            return instance;
        }
        public BaseRepository<T> GetService<T>() where T: IBaseEntity
        {
            return new BaseRepository<T>(sessionFactory.OpenSession());
        }

        private static ISessionFactory CreateSessionFactory()
        {
            AutoPersistenceModel model = AutoMap
                       .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                       .Where(t => t.Namespace == "Esquenta.Entities");

            return Fluently.Configure()
                //.Database(SQLiteConfiguration.Standard
                //.UsingFile(DbFile))
                .Database(MsSqlConfiguration.MsSql2008
                .ShowSql()
                .ConnectionString(c => c
                    .Server("localhost")
                    .Database("esquenta")
                    .Username("sa")
                    .Password("$splfiscal10"))
                   )
                .Mappings(m => m.AutoMappings.Add(model))
                //.ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            //if (File.Exists(DbFile))
            //    File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}