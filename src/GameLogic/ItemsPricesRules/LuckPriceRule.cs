namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for luck option.
    /// </summary>
    public class LuckPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            // add 25% for luck
            if (item.ItemOptions.Any(o => o.ItemOption.OptionType == ItemOptionTypes.Luck))
            {
                price += price * 25 / 100;
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
