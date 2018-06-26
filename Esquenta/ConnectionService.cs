using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;
using Esquenta.Properties;
using Esquenta.Repository;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace Esquenta
{
    public class ConnectionService
    {
        private static ConnectionService _instance;

        private static ComandaRepository _comandaRepository;
        private static ItemVendaRepository _itemVendaRepository;
        private static ProdutoRepository _produtoRepository;
        private static VendaRepository _vendaRepository;
        private static ProdutoItemRepository _produtoItemRepository;
        private static EntradaProdutoRepository _entradaProdutoRepository;
        private static PeriodoVendaRepository _periodoVendaRepository;
        private static string _ipdb = "";
        private readonly ISession _session;

        private readonly ISessionFactory _sessionFactory = CreateSessionFactory();

        public ConnectionService()
        {
            _instance = this;
            _session = _sessionFactory.OpenSession();
        }

        public string GetIPServer()
        {
            return _ipdb;
        }

        public static ConnectionService GetInstance()
        {
            if (_instance == null) _instance = new ConnectionService();

            return _instance;
        }

        public ProdutoRepository GetProdutoRepository()
        {
            if (_produtoRepository == null) _produtoRepository = new ProdutoRepository(_session);
            return _produtoRepository;
        }

        public VendaRepository GetVendaRepository()
        {
            //if (!_session.IsConnected)
            //{
            //    _session = _sessionFactory.OpenSession();
            //    _vendaRepository = null;
            //}
            if (_vendaRepository == null) _vendaRepository = new VendaRepository(_session);
            return _vendaRepository;
        }

        public ComandaRepository GetComandaRepository()
        {
            if (_comandaRepository == null) _comandaRepository = new ComandaRepository(_session);
            return _comandaRepository;
        }

        public ItemVendaRepository GetItemVendaRepository()
        {
            if (_itemVendaRepository == null) _itemVendaRepository = new ItemVendaRepository(_session);
            return _itemVendaRepository;
        }

        public ProdutoItemRepository GetProdutoItemRepository()
        {
            if (_produtoItemRepository == null) _produtoItemRepository = new ProdutoItemRepository(_session);
            return _produtoItemRepository;
        }

        public EntradaProdutoRepository GetEntradaProdutoRepository()
        {
            if (_entradaProdutoRepository == null) _entradaProdutoRepository = new EntradaProdutoRepository(_session);
            return _entradaProdutoRepository;
        }

        public PeriodoVendaRepository GetPeriodoVendaRepository()
        {
            if (_periodoVendaRepository == null) _periodoVendaRepository = new PeriodoVendaRepository(_session);
            return _periodoVendaRepository;
        }

        public void MakeBackup()
        {
            var connectionString = Settings.Default.ConnectionString;
            var backupFolder = Settings.Default.BackupFolder;

            var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

            var backupFileName = $"{backupFolder}\\{sqlConStrBuilder.InitialCatalog}.bak";

            using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
            {
                var query = $"BACKUP DATABASE {sqlConStrBuilder.InitialCatalog} TO DISK='{backupFileName}'";

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show(@"Backup realizado.");
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var model = AutoMap
                .Assembly(Assembly.GetCallingAssembly())
                .Where(t => t.Namespace == "Esquenta.Entities");

            var connectionString = Settings.Default.ConnectionString;

            var builder = new SqlConnectionStringBuilder(connectionString);
            _ipdb = builder.DataSource;

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.AutoMappings.Add(model))
                .BuildSessionFactory();

            //return Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(
            //    x => x.Server("localhost").
            //        Username("root").
            //        Password("$splfiscal10").
            //        Database("esquenta")
            //    ))
            //    .Mappings(m => m.AutoMappings.Add(model))
            //    .BuildSessionFactory();
        }
    }
}