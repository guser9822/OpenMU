namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for item with guardian options.
    /// </summary>
    public class GuardianOptionsPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            if (item.ItemOptions.Any(o => o.ItemOption.OptionType == ItemOptionTypes.GuardianOption))
            {
                priceCalculation.Price += priceCalculation.Price * 16 / 100;
            }

            return priceCalculation;
        }
    }
}
