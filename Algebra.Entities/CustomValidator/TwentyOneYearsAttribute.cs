using Algebra.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Algebra.Entities.CustomValidator
{
    public class TwentyOneYearsAttribute : ValidationAttribute, IClientModelValidator
    {
        private int _year;

        public TwentyOneYearsAttribute(int year)
        {
            _year = year;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var container = validationContext.ObjectInstance;
            if (container.GetType() == typeof(MemberViewModels))
            {
                if (((MemberViewModels)container).DateOfBirth.AddYears(21) < DateTime.Now)
                {
                    return new ValidationResult(GetErrorMessage());
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else if (container.GetType() == typeof(SpouseViewModels))
            {
                if (((SpouseViewModels)container).DateOfBirth.AddYears(21) < DateTime.Now)
                {
                    return new ValidationResult(GetErrorMessage());
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"Age must be greater than equal to '{_year}' years.";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-twentyoneyears"] = GetErrorMessage();
            //context.Attributes["min"] = DateTime.Now.AddYears(-21).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            //context.Attributes["max"] = DateTime.Now.AddYears(-121).ToString(CultureInfo.InvariantCulture);
           // context.Attributes["pattern"] = "[0-9]{4}-[0-9]{2}-[0-9]{2}";

            var year = _year.ToString(CultureInfo.InvariantCulture);
            context.Attributes["data-val-twentyoneyears-year"] = year;
        }
    }
}
