﻿namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for taking into account maximum durability of the item.
    /// </summary>
    public class MaximumDurabilityPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            var maxDurability = item.GetMaximumDurabilityOfOnePiece();
            if (maxDurability > 1 && maxDurability > item.Durability)
            {
                float multiplier = 1.0f - ((float)item.Durability / maxDurability);
                long loss = (long)(price * 0.6 * multiplier);
                price -= loss;
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
