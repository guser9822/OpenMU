namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for item with wings options.
    /// </summary>
    public class WingOptionsPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            // For each wing option, add 25%
            var wingOptionCount = item.ItemOptions.Count(o => o.ItemOption.OptionType == ItemOptionTypes.Wing);
            for (int i = 0; i < wingOptionCount; i++)
            {
                priceCalculation.Price += (long)(priceCalculation.Price * 0.25);
            }

            return priceCalculation;
        }
    }
}
