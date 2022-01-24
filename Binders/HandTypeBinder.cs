using Microsoft.AspNetCore.Mvc.ModelBinding;

using Spinutech.Models;

using System;
using System.Threading.Tasks;

namespace Spinutech.Binders
{
    /// <summary>
    /// Uses data- attributes of option to bind select list to type Card
    /// </summary>
    public class HandTypeBinder : IModelBinder
    {
   
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.ModelName;

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            // Values will be a list of strings
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var model = new Hand();
            model.Cards = new System.Collections.Generic.List<Card>();
            foreach (var val in valueProviderResult.Values)
            {
                // each card stored as suite,cardValue
                var parts = val.Split(new char[] { ',' });
                if (Enum.TryParse<Suit>(parts[0], out Suit resultSuit))
                {
                    if (Enum.TryParse<CardValue>(parts[1], out CardValue resultValue))
                    {
                        model.Cards.Add(new Card
                        {
                            Suit = resultSuit,
                            Value = resultValue
                        });
                    }
                }
            }

            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
