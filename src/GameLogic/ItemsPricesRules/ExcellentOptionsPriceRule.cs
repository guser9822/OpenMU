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
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            // For each excellent option double the value
            var excCount = item.ItemOptions.Count(o => o.ItemOption.OptionType == ItemOptionTypes.Excellent);
            for (int i = 0; i < excCount; i++)
            {
                price += price;
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
