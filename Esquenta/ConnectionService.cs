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

        private static ComandaRepository _comandaRepository = null;
        private static ItemVendaRepository _itemVendaRepository = null;
        private static ProdutoRepository _produtoRepository = null;
        private static VendaRepository _vendaRepository = null;
        private static ProdutoItemRepository _produtoItemRepository = null;
        private static EntradaProdutoRepository _entradaProdutoRepository = null;
        private static PeriodoVendaRepository _periodoVendaRepository = null;

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

        public ProdutoRepository GetProdutoRepository()
        {
            if (_produtoRepository == null)
            {
                _produtoRepository = new ProdutoRepository(sessionFactory.OpenSession());
            }
            return _produtoRepository;
        }

        public VendaRepository GetVendaRepository()
        {
            if (_vendaRepository == null)
            {
                _vendaRepository = new VendaRepository(sessionFactory.OpenSession());
            }
            return _vendaRepository;
        }

        public ComandaRepository GetComandaRepository()
        {
            if (_comandaRepository == null)
            {
                _comandaRepository = new ComandaRepository(sessionFactory.OpenSession());
            }
            return _comandaRepository;
        }

        public ItemVendaRepository GetItemVendaRepository()
        {
            if (_itemVendaRepository == null)
            {
                _itemVendaRepository = new ItemVendaRepository(sessionFactory.OpenSession());
            }
            return _itemVendaRepository;
        }

        public ProdutoItemRepository GetProdutoItemRepository()
        {
            if (_produtoItemRepository == null)
            {
                _produtoItemRepository = new ProdutoItemRepository(sessionFactory.OpenSession());
            }
            return _produtoItemRepository;
        }

        public EntradaProdutoRepository GetEntradaProdutoRepository()
        {
            if (_entradaProdutoRepository == null)
            {
                _entradaProdutoRepository = new EntradaProdutoRepository(sessionFactory.OpenSession());
            }
            return _entradaProdutoRepository;
        }

        public PeriodoVendaRepository GetPeriodoVendaRepository()
        {
            if (_periodoVendaRepository == null)
            {
                _periodoVendaRepository = new PeriodoVendaRepository(sessionFactory.OpenSession());
            }
            return _periodoVendaRepository;
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
                .BuildSessionFactory();
        }
    }
}