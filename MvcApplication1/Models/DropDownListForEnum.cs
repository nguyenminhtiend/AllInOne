using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class DropDownListForEnum
    {
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, IDictionary<string, object> htmlAttributes = null)
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            var prop = expression.Compile().Invoke(htmlHelper.ViewData.Model);
            var items = from value in values
                        select new SelectListItem
                        {
                            Text = value.ToDescription(),
                            Value = value.ToString(),
                            Selected = (value.Equals(prop))
                        };

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
    }
}