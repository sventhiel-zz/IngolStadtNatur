using FluentNHibernate.Mapping;
using IngolStadtNatur.Entities.NH.Common;
using IngolStadtNatur.Entities.NH.Observations;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace IngolStadtNatur.Entities.NH.Authentication
{
    public class User : BaseEntity, IUser<long>
    {
        public User()
        {
            Observations = new List<Observation>();
        }

        public virtual int AccessFailedCount { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Email { get; set; }
        public virtual string FullName { get; set; }
        public virtual bool IsEmailConfirmed { get; set; }
        public virtual bool LockedOutEnabled { get; set; }
        public virtual DateTime? LockedOutEndDate { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Observation> Observations { get; set; }
        public virtual string Password { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string Street { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual string UserName { get; set; }
        public virtual string ZipCode { get; set; }
    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");

            Id(m => m.Id);
            Version(m => m.Version);

            Map(m => m.AccessFailedCount);
            Map(m => m.City);
            Map(m => m.Country);
            Map(m => m.DateOfBirth);
            Map(m => m.Email);
            Map(m => m.FullName);
            Map(m => m.IsEmailConfirmed);
            Map(m => m.LockedOutEnabled);
            Map(m => m.LockedOutEndDate);
            HasMany(m => m.Logins)
                .Cascade.All()
                .Inverse();
            HasMany(m => m.Observations)
                .Cascade.All()
                .Inverse();
            Map(m => m.Password);
            Map(m => m.SecurityStamp);
            Map(m => m.Street);
            Map(m => m.TwoFactorEnabled);
            Map(m => m.UserName);
            Map(m => m.ZipCode);
        }
    }
}