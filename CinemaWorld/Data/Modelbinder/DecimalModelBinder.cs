using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace CinemaWorld.Data.Modelbinder
{
    //Solving the problem: Rating must be between 0 and 10
    public class DecimalModelBinder : IModelBinder
    {
        private readonly ModelMetadata modelMetadata;

        public DecimalModelBinder(ModelMetadata modelMetadata)
        {
            this.modelMetadata = modelMetadata;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            decimal? actualValue = null;
            bool success = false;

            if (valueResult != ValueProviderResult.None && !String.IsNullOrEmpty(valueResult.FirstValue))
            {
                try
                {
                    string decValue = valueResult.FirstValue;
                    decValue = decValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    actualValue = Convert.ToDecimal(decValue, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (FormatException e)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
                }
            }
            else
            {
                if (modelMetadata.ModelType == typeof(Decimal?))
                {
                    success = true;
                }
            }

            if (success)
            {
                bindingContext.Result = ModelBindingResult.Success(actualValue);
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }
    }
}
