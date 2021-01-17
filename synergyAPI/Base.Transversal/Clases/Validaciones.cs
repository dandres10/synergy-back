namespace Base.Transversal.Clases
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Validaciones : ControllerBase
    {
        public static bool ObjIsNull(dynamic Obj) => Obj == null ? true : false;
    }

    public class GuidRequeridoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.Equals(Guid.Empty))
                return new ValidationResult("El campo Id es requerido.");

            return ValidationResult.Success;
        }
    }
}