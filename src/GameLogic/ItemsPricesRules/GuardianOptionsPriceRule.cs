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
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            if (item.ItemOptions.Any(o => o.ItemOption.OptionType == ItemOptionTypes.GuardianOption))
            {
                price += price * 16 / 100;
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
