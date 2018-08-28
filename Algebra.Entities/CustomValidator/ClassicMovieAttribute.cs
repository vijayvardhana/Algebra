using Algebra.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Algebra.Entities.CustomValidator
{
    public class ClassicMovieAttribute : ValidationAttribute, IClientModelValidator
    {
        private int _year;

        public ClassicMovieAttribute(int year)
        {
            _year = year;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            MemberViewModels movie = (MemberViewModels)validationContext.ObjectInstance;

            if (movie.DateOfBirth.AddYears(21) < DateTime.Now)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"Classic movies must have a release year earlier than {_year}.";
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-classicmovie"] = GetErrorMessage();

            var year = _year.ToString(CultureInfo.InvariantCulture);
            context.Attributes["data-val-classicmovie-year"] = year;
        }
    }
}
