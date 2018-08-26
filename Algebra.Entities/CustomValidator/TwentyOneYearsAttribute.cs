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
                if (((MemberViewModels)container).M_DateOfBirth.AddYears(21) < DateTime.Now)
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
                if (((SpouseViewModels)container).S_DateOfBirth.AddYears(21) < DateTime.Now)
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
            return $"Member age must be greater than {_year}.";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-twentyoneyears"] = GetErrorMessage();

            var year = _year.ToString(CultureInfo.InvariantCulture);
            context.Attributes["data-val-twentyoneyears-year"] = year;
        }
    }
}
