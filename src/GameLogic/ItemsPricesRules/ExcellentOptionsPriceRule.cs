namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for item with exellent options.
    /// </summary>
    public class ExcellentOptionsPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            // For each excellent option double the value
            var excCount = item.ItemOptions.Count(o => o.ItemOption.OptionType == ItemOptionTypes.Excellent);
            for (int i = 0; i < excCount; i++)
            {
                priceCalculation.Price += priceCalculation.Price;
            }

            return priceCalculation;
        }
    }
}
