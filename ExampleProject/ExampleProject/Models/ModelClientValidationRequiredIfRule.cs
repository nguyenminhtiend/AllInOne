using System.Web.Mvc;

namespace ExampleProject.Models
{
    public class ModelClientValidationRequiredIfRule : ModelClientValidationRule
    {
        public ModelClientValidationRequiredIfRule(string errorMessage, string otherProperty, Comparison comparison, object value)
        {
            ErrorMessage = errorMessage;
            ValidationType = "requiredif";
            ValidationParameters.Add("other", otherProperty);
            ValidationParameters.Add("comp", comparison.ToString().ToLower());
            ValidationParameters.Add("value", value.ToString().ToLower());
        }
    }
}
