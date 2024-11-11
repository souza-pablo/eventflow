using System.ComponentModel.DataAnnotations;

namespace EventFlow.Attributes
{
    public class DataNascimentoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateOnly dataNascimento && dataNascimento > DateOnly.FromDateTime(DateTime.Now))
            {
                return new ValidationResult("A data de nascimento não pode ser posterior à data atual.");
            }

            return ValidationResult.Success;
        }
    }
}
