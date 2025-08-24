using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.ComponentModel.DataAnnotations;

using Custom_Validations_Prj.Models;

namespace Custom_Validations_Prj.CustomValidations

{

    public class ValidateJoiningDate : ValidationAttribute

    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            DateTime entered_doj = Convert.ToDateTime(value);

            if (entered_doj <= DateTime.Now)
            {
                return ValidationResult.Success;
            }

            else
                return new ValidationResult(ErrorMessage);

        }

    }

}
