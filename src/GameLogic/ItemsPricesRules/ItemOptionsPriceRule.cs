namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for item options.
    /// </summary>
    public class ItemOptionsPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            var opt = item.ItemOptions.FirstOrDefault(o => o.ItemOption.OptionType == ItemOptionTypes.Option);
            var optionLevel = opt?.Level ?? 0;

            // Item Options (1 to 4, or 4 to 16)
            switch (optionLevel)
            {
                case 0:
                    break;
                case 1:
                    priceCalculation.Price += (long)(priceCalculation.Price * 0.6);
                    break;
                default:
                    priceCalculation.Price += (long)(priceCalculation.Price * 0.7 * Math.Pow(2, optionLevel - 1));
                    break;
            }

            return priceCalculation;
        }
    }
}
