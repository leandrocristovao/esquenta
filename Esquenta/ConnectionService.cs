using Esquenta.Repository;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Esquenta
{
    public class ConnectionService
    {
        private static ConnectionService instance = null;

        private ISessionFactory sessionFactory = CreateSessionFactory();
        private ISession _session;

        public ConnectionService()
        {
            instance = this;
            _session = sessionFactory.OpenSession();
        }

        public static ConnectionService GetInstance()
        {
            if (instance == null)
            {
                instance = new ConnectionService();
            }

            return instance;
        }

        public ProdutoRepository GetProdutoRepository()
        {
            _session.Close();
            _session = sessionFactory.OpenSession();

            return new ProdutoRepository(_session);
        }

        public VendaRepository GetVendaRepository()
        {
            _session.Close();
            _session = sessionFactory.OpenSession();

            return new VendaRepository(_session);
        }

        public ComandaRepository GetComandaRepository()
        {
            _session.Close();
            _session = sessionFactory.OpenSession();

            return new ComandaRepository(_session);
        }

        public ItemVendaRepository GetItemVendaRepository()
        {
            _session.Close();
            _session = sessionFactory.OpenSession();

            return new ItemVendaRepository(_session);
        }

        public ProdutoItemRepository GetProdutoItemRepository()
        {
            _session.Close();
            _session = sessionFactory.OpenSession();
            
            return new ProdutoItemRepository(_session);
        }

        public EntradaProdutoRepository GetEntradaProdutoRepository()
        {
            _session.Close();
            _session = sessionFactory.OpenSession();
            
            return new EntradaProdutoRepository(_session);
        }

        public PeriodoVendaRepository GetPeriodoVendaRepository()
        {
            _session.Close();
            _session = sessionFactory.OpenSession();

            return new PeriodoVendaRepository(_session);
        }

        private static ISessionFactory CreateSessionFactory()
        {
            AutoPersistenceModel model = AutoMap
                       .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                       .Where(t => t.Namespace == "Esquenta.Entities");

            string connectionString = Properties.Settings.Default.ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.AutoMappings.Add(model))
                //.Cache(x=>x.Not.UseQueryCache())
                .BuildSessionFactory();
        }
    }
}