using IngolStadtNatur.Entities.NH.Common;

namespace IngolStadtNatur.Entities.NH.Authentication
{
    public class Login : BaseEntity
    {
        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual User User { get; set; }
    }
}
