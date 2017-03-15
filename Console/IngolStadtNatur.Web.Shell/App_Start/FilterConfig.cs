using IngolStadtNatur.Persistence.NH;
using System.Web.Mvc;

namespace IngolStadtNatur.Web.Shell
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PersistenceAttribute());
        }
    }
}
