using System.ComponentModel.DataAnnotations;

namespace Projeto_SPA.Api.ApiHelpers
{
    public static class ValidationHelper
    {
        public static string[] ValidateModel<T>(T model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);

            bool isValid = Validator.TryValidateObject(model, context, validationResults, true);

            return isValid ? Array.Empty<string>() : validationResults.Select(r => r.ErrorMessage!).ToArray();
        }
    }
}
