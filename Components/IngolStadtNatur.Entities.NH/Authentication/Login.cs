using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;

namespace IngolStadtNatur.Entities.NH.Authentication
{
    public class Login : BaseEntity
    {
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual User User { get; set; }
    }

    public class LoginMap : ClassMap<Login>
    {
        public LoginMap()
        {
            Table("Logins");

            Id(m => m.Id);
            Version(m => m.Version);

            Map(m => m.LoginProvider);
            Map(m => m.ProviderKey);
            References(m => m.User)
                .Column("UserRef")
                .Cascade.All();
        }
    }
}
