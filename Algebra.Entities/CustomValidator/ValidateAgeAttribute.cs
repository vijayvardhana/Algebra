using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Algebra.Entities.CustomValidator
{
    public class ValidateAgeAttribute : ValidationAttribute, IClientModelValidator
    {
        public DateTime MinimumDate { get; private set; }
        public DateTime MaximumDate { get; private set; }
        private readonly int _min;
        private readonly int _max;
        public ValidateAgeAttribute(
        int minimumAgeProperty,
        int maximumAgeProperty)
        : base()
        {
            _min = minimumAgeProperty;
            _max = maximumAgeProperty;
            MaximumDate = DateTime.Now.AddYears(minimumAgeProperty * -1);
            MinimumDate = DateTime.Now.AddYears(maximumAgeProperty * -1);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime parsedValue = (DateTime)value;

                if (parsedValue <= MinimumDate || parsedValue >= MaximumDate)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;

        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-validateage"] = FormatErrorMessage(context.ModelMetadata.DisplayName);
            context.Attributes["minumumdate"] = MinimumDate.ToShortDateString();
            context.Attributes["maximumdate"] = MaximumDate.ToShortDateString();
            context.Attributes["data-val-min"] = _min.ToString();
            context.Attributes["data-val-max"] = _max.ToString();
        }

        public override string FormatErrorMessage(string name)
        {
          return  $"Your age is invalid, your {name} should fall between {MinimumDate.ToShortDateString()} and {MaximumDate.ToShortDateString()}";
        }
    }
}
