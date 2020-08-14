namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for rings, pendants, pets, misc, orbs and scrolls.
    /// </summary>
    public class RingsPendantsOrbsPetsScrollPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            if ((item.Definition.Group == 12 && item.Definition.Number > 6) || item.Definition.Group == 13 || item.Definition.Group == 15)
            {
                priceCalculation.Price = (priceCalculation.DropLevel * priceCalculation.DropLevel * priceCalculation.DropLevel) + 100;
                priceCalculation.StopPriceCalculation = true;
            }

            return priceCalculation;
        }
    }
}
