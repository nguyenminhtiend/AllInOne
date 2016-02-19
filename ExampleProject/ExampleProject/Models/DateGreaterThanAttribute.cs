﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ExampleProject.Models
{
    //[AttributeUsage(AttributeTargets.Property, AllowMultiple=true)]
    public class DateGreaterThanAttribute : ValidationAttribute, IClientValidatable
    {
        string otherPropertyName;                

        public DateGreaterThanAttribute(string otherPropertyName, string errorMessage)
            : base(errorMessage)
        {
            this.otherPropertyName = otherPropertyName;
        }

        /// <summary>
        /// Format the error message filling in the name of the property to validate and the reference one.
        /// </summary>
        /// <param name="name">The name of the property to validate</param>
        /// <returns>The formatted error message</returns>
        public override string FormatErrorMessage(string name)
        {
            // In our case this will return: "Estimated end date must be greater than Start date"
            return string.Format(ErrorMessageString, name, otherPropertyName);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult validationResult = ValidationResult.Success; 
            try
            {
                // Using reflection we can get a reference to the other date property, in this example the project start date
                var otherPropertyInfo = validationContext.ObjectType.GetProperty(this.otherPropertyName);                
                // Let's check that otherProperty is of type DateTime as we expect it to be
                if (otherPropertyInfo.PropertyType == new DateTime().GetType())
                {
                    DateTime toValidate = (DateTime)value;
                    DateTime referenceProperty = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);                    
                    // if the end date is lower than the start date, than the validationResult will be set to false and return
                    // a properly formatted error message
                    if (toValidate.CompareTo(referenceProperty) < 1)
                    {
                        //string message = FormatErrorMessage(validationContext.DisplayName);
                        //validationResult = new ValidationResult(message);
                        validationResult = new ValidationResult(ErrorMessageString);
                    }
                }
                else
                {
                    validationResult = new ValidationResult("An error occurred while validating the property. OtherProperty is not of type DateTime");
                }
            }
            catch (Exception ex)
            {
                // Do stuff, i.e. log the exception
                // Let it go through the upper levels, something bad happened
                throw ex;
            }

            return validationResult;
        }
         
        
        #region IClientValidatable Members

        /// <summary>
        ///  
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            string errorMessage = ErrorMessageString;

            // The value we set here are needed by the jQuery adapter
            var dateGreaterThanRule = new ModelClientValidationRule
            {
                ErrorMessage = errorMessage,
                ValidationType = "dategreaterthan"
            };
            //"otherpropertyname" is the name of the jQuery parameter for the adapter, must be LOWERCASE!
            dateGreaterThanRule.ValidationParameters.Add("otherpropertyname", otherPropertyName); 

            yield return dateGreaterThanRule;
        }

        #endregion
         
    }
}