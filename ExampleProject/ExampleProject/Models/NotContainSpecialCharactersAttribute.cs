using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ExampleProject.Models
{
    public class NotContainSpecialCharactersAttribute : ValidationAttribute, IClientValidatable
    {


        private const string Pattern = "^[^<>]*$";
        public string ErrorMessage { get; set; }
        public NotContainSpecialCharactersAttribute(string errorMessage)
        {
            this.ErrorMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }

            if (!Regex.IsMatch(value.ToString(), Pattern))
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }

      

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            return new[]
           {
               new ModelClientValidationNotContainSpecialCharactersRule(FormatErrorMessage(""),Pattern)
           };
        }
       
    }
    public class ModelClientValidationNotContainSpecialCharactersRule : ModelClientValidationRule
    {
        public ModelClientValidationNotContainSpecialCharactersRule(string errorMessage, string pattern)
        {
            ErrorMessage = errorMessage;
            ValidationType = "containspecialcharacters";
            ValidationParameters["regex"] = pattern;
        }
    }
}