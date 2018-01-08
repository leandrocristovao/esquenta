using Esquenta.Repository;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Esquenta
{
    public class ConnectionService
    {
        private static ConnectionService instance = null;

        private ISessionFactory _sessionFactory = CreateSessionFactory();
        private ISession _session;

        private static ComandaRepository _comandaRepository = null;
        private static ItemVendaRepository _itemVendaRepository = null;
        private static ProdutoRepository _produtoRepository = null;
        private static VendaRepository _vendaRepository = null;
        private static ProdutoItemRepository _produtoItemRepository = null;
        private static EntradaProdutoRepository _entradaProdutoRepository = null;
        private static PeriodoVendaRepository _periodoVendaRepository = null;
        private static string _IPDB = "";

        public ConnectionService()
        {
            instance = this;
            _session = _sessionFactory.OpenSession();
        }
        public string GetIPServer()
        {
            return _IPDB;
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
                _produtoRepository = new ProdutoRepository(_session);
            }
            return _produtoRepository;
        }

        public VendaRepository GetVendaRepository()
        {
            //if (!_session.IsConnected)
            //{
            //    _session = _sessionFactory.OpenSession();
            //    _vendaRepository = null;
            //}
            if (_vendaRepository == null)
            {
                _vendaRepository = new VendaRepository(_session);
            }
            return _vendaRepository;
        }

        public ComandaRepository GetComandaRepository()
        {
            if (_comandaRepository == null)
            {
                _comandaRepository = new ComandaRepository(_session);
            }
            return _comandaRepository;
        }

        public ItemVendaRepository GetItemVendaRepository()
        {
            if (_itemVendaRepository == null)
            {
                _itemVendaRepository = new ItemVendaRepository(_session);
            }
            return _itemVendaRepository;
        }

        public ProdutoItemRepository GetProdutoItemRepository()
        {
            if (_produtoItemRepository == null)
            {
                _produtoItemRepository = new ProdutoItemRepository(_session);
            }
            return _produtoItemRepository;
        }

        public EntradaProdutoRepository GetEntradaProdutoRepository()
        {
            if (_entradaProdutoRepository == null)
            {
                _entradaProdutoRepository = new EntradaProdutoRepository(_session);
            }
            return _entradaProdutoRepository;
        }

        public PeriodoVendaRepository GetPeriodoVendaRepository()
        {
            if (_periodoVendaRepository == null)
            {
                _periodoVendaRepository = new PeriodoVendaRepository(_session);
            }
            return _periodoVendaRepository;
        }

        public void MakeBackup()
        {
            var connectionString = Properties.Settings.Default.ConnectionString;
            var backupFolder = Properties.Settings.Default.BackupFolder;

            var sqlConStrBuilder = new SqlConnectionStringBuilder(connectionString);

            var backupFileName = String.Format("{0}\\{1}.bak",
                backupFolder, sqlConStrBuilder.InitialCatalog);

            using (var connection = new SqlConnection(sqlConStrBuilder.ConnectionString))
            {
                var query = String.Format("BACKUP DATABASE {0} TO DISK='{1}'",
                    sqlConStrBuilder.InitialCatalog, backupFileName);

                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Backup realizado.");
        }

        private static ISessionFactory CreateSessionFactory()
        {
            AutoPersistenceModel model = AutoMap
                       .Assembly(System.Reflection.Assembly.GetCallingAssembly())
                       .Where(t => t.Namespace == "Esquenta.Entities");

            string connectionString = Properties.Settings.Default.ConnectionString;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            _IPDB = builder.DataSource;

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.AutoMappings.Add(model))
                .BuildSessionFactory();
        }
    }
}