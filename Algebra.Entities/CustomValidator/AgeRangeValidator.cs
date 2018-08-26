using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Algebra.Entities.CustomValidator
{
    public class AgeRangeValidator : ValidationAttribute, IClientModelValidator
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }

            int age = 0;
            age = DateTime.Now.Year - Convert.ToDateTime(value).Year;
            if (age >= MinAge && age <= MaxAge)
            {
                return null; // Validation success
            }
            else
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                // error 
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //THIS IS FOR SET VALIDATION RULES CLIENT SIDE

            var rule = new ModelClientValidationRule()
            {
                ValidationType = "agerangevalidator",
                ErrorMessage = FormatErrorMessage(metadata.DisplayName)
            };

            rule.ValidationParameters["minage"] = MinAge;
            rule.ValidationParameters["maxage"] = MaxAge;
            yield return rule;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-agerange"] = "Error message";
        }
    }

    public class ModelClientValidationRule
    {
        private readonly Dictionary<string, object> _validationParameters = new Dictionary<string, object>();
        private string _validationType;

        public string ErrorMessage { get; set; }

        public IDictionary<string, object> ValidationParameters
        {
            get { return _validationParameters; }
        }

        public string ValidationType
        {
            get { return _validationType ?? String.Empty; }
            set { _validationType = value; }
        }
    }
}
