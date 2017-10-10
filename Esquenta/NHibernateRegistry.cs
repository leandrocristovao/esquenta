using Esquenta.Models;
using Esquenta.Repository.Interfaces;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Esquenta
{
    public class NHibernateRegistry : Registry
    {
        ISessionFactory m_SessionFactory;
        public NHibernateRegistry()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();

            // Add class mappings to configuration object
            Assembly thisAssembly = typeof(Produto).Assembly;
            cfg.AddAssembly(thisAssembly);

            // Create session factory from configuration object
            m_SessionFactory = cfg.BuildSessionFactory();
        }

        //private static ISessionFactory GetSessionFactory()
        //{
        //    return Fluently.Configure()
        //        .Database(
        //        MsSqlConfiguration.MsSql2008.ConnectionString(
        //            @"Data Source=.\SQLEXPRESS;Initial Catalog=ContatoDevmedia;Persist Security Info=True;User ID=sa;Password=123456")
        //            //habilita a exibição dos SQL disparados contra o banco de dados no output do VS
        //            .ShowSql())
        //        .Mappings(c => c.FluentMappings.AddFromAssemblyOf())
        //        .ExposeConfiguration(c => new SchemaExport(c).Create(false, true))
        //        .BuildSessionFactory();
        //}
    }
}
