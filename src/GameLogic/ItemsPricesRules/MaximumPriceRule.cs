namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for used if the price exeeds the maximum.
    /// </summary>
    public class MaximumPriceRule : ItemPriceRule
    {
        private const long MaximumPrice = 3000000000;

        /// <inheritdoc/>
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            if (price > MaximumPrice)
            {
                price = MaximumPrice;
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
