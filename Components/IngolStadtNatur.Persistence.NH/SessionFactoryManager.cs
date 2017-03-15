using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using IngolStadtNatur.Entities.NH.Common;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;

namespace IngolStadtNatur.Persistence.NH
{
    public static class SessionFactoryManager
    {
        public static ISessionFactory SessionFactory;

        public static void Start(string connectionString, string createDatabase)
        {
            var config = Fluently.Configure()
                .Database(PostgreSQLConfiguration.PostgreSQL82
                    .Raw("hbm2ddl.keywords", "none")
                    .ConnectionString(c => c.Is(connectionString)))
                .Mappings(m =>
                {
                    m.FluentMappings.Conventions.Setup(c =>
                    {
                        c.Add<EnumConvention>();
                    });
                    m.FluentMappings.AddFromAssemblyOf<BaseEntity>();
                })
                .ExposeConfiguration(c =>
                {
                    c.Properties.Add("current_session_context_class", "web");
                });

            switch (createDatabase)
            {
                case "create":
                    config.ExposeConfiguration(CreateSchema);
                    break;

                case "update":
                    config.ExposeConfiguration(UpdateSchema);
                    break;

                case "validate":
                    config.ExposeConfiguration(ValidateSchema);
                    break;
            }

            SessionFactory = config.BuildSessionFactory();
        }

        private static void CreateSchema(Configuration cfg)
        {
            var schemaExport = new SchemaExport(cfg);
            schemaExport.Drop(false, true);
            schemaExport.Create(false, true);
        }

        private static void UpdateSchema(Configuration cfg)
        {
            var schemaUpdate = new SchemaUpdate(cfg);
            schemaUpdate.Execute(false, true);
        }

        private static void ValidateSchema(Configuration cfg)
        {
            var schemaValidate = new SchemaValidator(cfg);
            schemaValidate.Validate();
        }
    }

    public class EnumConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        #region IPropertyConvention Members

        public void Apply(IPropertyInstance instance)
        {
            instance.CustomType(instance.Property.PropertyType);
        }

        #endregion IPropertyConvention Members

        #region IPropertyConventionAcceptance Members

        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Property.PropertyType.IsEnum ||
            (x.Property.PropertyType.IsGenericType &&
             x.Property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) &&
             x.Property.PropertyType.GetGenericArguments()[0].IsEnum)
            );
        }

        #endregion IPropertyConventionAcceptance Members
    }
}
