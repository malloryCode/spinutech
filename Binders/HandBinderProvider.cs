using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

using Spinutech.Helpers;
using Spinutech.Models;

using System;

namespace Spinutech.Binders
{
    public class HandTypeBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Hand))
            {
                return new BinderTypeModelBinder(typeof(HandTypeBinder));
            }

            return null;
        }
    }
}
