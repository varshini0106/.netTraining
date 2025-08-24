using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Custom_Validations_Prj.Models;

namespace Custom_Validations_Prj.CustomValidations
{
    public class ValidBirthDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime entered_dob = Convert.ToDateTime(value);
            DateTime today = DateTime.Now;
            int age;
            if (today.Month > entered_dob.Month)
            {
                age = today.Year - entered_dob.Year;
            }
            else
            {
                age = (today.Year - entered_dob.Year) - 1;
            }
            if (entered_dob < DateTime.Now && age > 21 && age < 25)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}