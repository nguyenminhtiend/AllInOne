using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcApplication1.Models
{
    public static class HtmlExtension
    {
        public static string ToDescription<TEnum>(this TEnum e)
        {
            var fi = e.GetType().GetField(e.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return (attributes.Length > 0) ? attributes[0].Description : e.ToString();
        }
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

        public static MvcHtmlString EmailEditor(this HtmlHelper htmlHelper, EmailProperty emailProperty)
        {
            const string template = @"<div class='modal fade' id='{0}' tabindex='-1' role='dialog' aria-labelledby='exampleModalLabel' aria-hidden='true'>
                                    <div class='modal-dialog'>
                                        <div class='modal-content'>
                                            <div class='modal-header'>
                                                <button type='button' class='close' data-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>
                                                <h4 class='modal-title'>{1}</h4>
                                            </div>
                                            <div class='modal-body'>
                                                <form id='{2}_form' action='{3}' method='POST' >
                                                    <input type='hidden' id='{4}_Receivers' name='Receivers' >
                                                    <label>
                                                        Select which Contact you would like to include:
                                                    </label>
                                                    <div class='checkbox'>
                                                        <label>
                                                            <input type='checkbox' name='IsBusiness' value='true'>
                                                            Business Contacts
                                                        </label>
                                                    </div>
                                                    <div class='checkbox'>
                                                        <label>
                                                            <input type='checkbox' name='IsInvoice' value='true'>
                                                            Invoice Contacts
                                                        </label>
                                                    </div>
                                                    <br/><br/>
                                                    <div class='form-group'>
                                                        <input type='text' class='form-control' name='Subject' placeholder='Subject' >
                                                    </div>
                                                    <div class='form-group'>
                                                        <textarea class='form-control' rows='10' name='Content' placeholder='Content'></textarea>
                                                    </div>
                                                </form>
                                            </div>
                                            <div class='modal-footer'>
                                                <button type='button' class='btn btn-default btn-lg pull-left btn-left-email' data-dismiss='modal'>Back</button>
                                                <button type='button' class='btn btn-primary btn-lg pull-right' id='{5}_submit' style='padding-top: 5px; padding-bottom: 4px;'><span>Finish and</span><br/><span style='font-size:12px;'>Send Email</span></button>
                                            </div>
                                        </div>
                                    </div>
                                </div>";

             string script = @"<script>
                                    $(document).ready(function () {
                                        $('#{id}_submit').click(function () {
                                             $('#{id}_Receivers').val({6});
                                            $('#{id}_form').submit();
                                        });
                                    });
                                </script>";

            script = script.Replace("{id}", emailProperty.Id);
            script = script.Replace("{6}", emailProperty.GetListReceivers);

            string htmlString = string.Format(template, emailProperty.Id, emailProperty.Title, emailProperty.Id, emailProperty.Url, emailProperty.Id, emailProperty.Id) + script;
            return MvcHtmlString.Create(htmlString);
        }
    }
}