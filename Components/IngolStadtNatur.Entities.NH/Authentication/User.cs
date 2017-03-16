using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;
using IngolStadtNatur.Entities.NH.Observations;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Authentication
{
    public class User : BaseEntity, IUser<long>
    {
        public virtual string Email { get; set; }
        public virtual string FullName { get; set; }
        public virtual bool IsEmailConfirmed { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
        public virtual string Password { get; set; }
        public virtual string UserName { get; set; }

        public User()
        {
            Observations = new List<Observation>();
        }
    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");

            Id(m => m.Id);
            Version(m => m.Version);

            Map(m => m.Email);
            Map(m => m.FullName);
            Map(m => m.IsEmailConfirmed);
            HasMany(m => m.Observations)
                .Cascade.All()
                .Inverse();
            Map(m => m.Password);
            Map(m => m.UserName);
        }
    }
}
