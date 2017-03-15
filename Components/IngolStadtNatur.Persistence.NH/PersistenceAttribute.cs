using NHibernate;
using System.Web.Mvc;

namespace IngolStadtNatur.Persistence.NH
{
    public class PersistenceAttribute : SessionAttribute
    {
        protected ISession Session => SessionFactory.GetCurrentSession();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            Session.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var transaction = Session.Transaction;

            try
            {
                if (transaction != null && transaction.IsActive)
                    transaction.Commit();
            }
            catch
            {
                if (transaction != null && transaction.IsActive)
                    transaction.Rollback();
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
