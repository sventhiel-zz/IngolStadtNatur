using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace IngolStadtNatur.Utilities.Extensions
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString DisplayPlaceHolderFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            var metaData = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var resolvedDisplayName = metaData.DisplayName ?? metaData.PropertyName;

            if (!string.IsNullOrEmpty(resolvedDisplayName))
                return new MvcHtmlString(resolvedDisplayName);

            var htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            resolvedDisplayName = htmlFieldName.Split('.').Last();

            return new MvcHtmlString(resolvedDisplayName);
        }
    }
}
