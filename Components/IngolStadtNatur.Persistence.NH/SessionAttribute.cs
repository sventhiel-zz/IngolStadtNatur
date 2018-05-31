using NHibernate;
using NHibernate.Context;
using System.Web.Mvc;

namespace IngolStadtNatur.Persistence.NH
{
    public class SessionAttribute : ActionFilterAttribute
    {
        public SessionAttribute()
        {
            Order = 100;
        }

        protected ISessionFactory SessionFactory => SessionFactoryManager.SessionFactory;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = CurrentSessionContext.Unbind(SessionFactory);
            session.Close();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }
    }
}