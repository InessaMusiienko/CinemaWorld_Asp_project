using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CinemaWorld.Data.Modelbinder
{
    public class DecimalModelBindingProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentException(nameof(context));

            if (context.Metadata.ModelType == typeof(Decimal) || context.Metadata.ModelType == typeof(Decimal?))
            {
                return new DecimalModelBinder(context.Metadata);
            }

            return null;
        }
    }
}
