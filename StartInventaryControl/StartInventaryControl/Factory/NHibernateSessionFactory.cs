using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using StartInventaryControl.Map;
using StartInventaryControl.Repository;
using System;
using Configuration = NHibernate.Cfg.Configuration;
using Environment = NHibernate.Cfg.Environment;

namespace StartInventaryControl.Factory
{
    public class NHibernateSessionFactory
    {
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                try
                {
                    if (sessionFactory == null)
                    {
                        var configuration = new Configuration();
                        configuration.Configure();
                        SetSqlExceptionConverter(configuration);

                        sessionFactory = Fluently.Configure(configuration)
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.ProductMap>())
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.VariationMap>())
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.VariationTypeMap>())
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.SupplierMap>())
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.ProducEntryMap>())
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.ProductEntryItemMap>())
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.ProductIssueMap>())
                            .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Map.ProductIssueItemMap>())
                            .ExposeConfiguration(SchemaMetadataUpdater.QuoteTableAndColumns)
                            .BuildSessionFactory();
                    }
                    return sessionFactory;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static void SetSqlExceptionConverter(Configuration configuration)
        {
            switch (configuration.Properties["dialect"])
            {
                case "NHibernate.Dialect.SQLiteDialect":
                    {
                        configuration.SetProperty(Environment.SqlExceptionConverter, typeof(SQLiteExceptionConverter).AssemblyQualifiedName);
                        return;
                    }
                case "NHibernate.Dialect.MySQL5Dialect":
                    {
                        configuration.SetProperty(Environment.SqlExceptionConverter, typeof(MySqlExceptionConverter).AssemblyQualifiedName);
                        return;
                    }
            }
        }

    }
}
