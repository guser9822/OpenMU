namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Base price rule calculation used by non special items.
    /// </summary>
    public class BasePriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            priceCalculation.DropLevel = this.IncreaseDropLevelByItemLevel(item.Level, priceCalculation.DropLevel);
            if (!IsWing(item))
            {
                priceCalculation.Price = ((priceCalculation.DropLevel + 40) * priceCalculation.DropLevel * priceCalculation.DropLevel / 8) + 100;
            }

            return priceCalculation;
        }
    }
}
