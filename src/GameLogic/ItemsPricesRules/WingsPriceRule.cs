﻿namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for wings. If the item is not wings, it apply another calculation to the price.
    /// </summary>
    public class WingsPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            // Wings
            if (IsWing(item))
            {
                // maybe we have to exclude small wings here
                priceCalculation.Price = ((priceCalculation.DropLevel + 40) * priceCalculation.DropLevel * priceCalculation.DropLevel * 11) + 40000000;
            }

            return priceCalculation;
        }
    }
}
