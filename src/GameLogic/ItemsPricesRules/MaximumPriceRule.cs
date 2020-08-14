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
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            if (priceCalculation.Price > MaximumPrice)
            {
                priceCalculation.Price = MaximumPrice;
            }

            return priceCalculation;
        }
    }
}
