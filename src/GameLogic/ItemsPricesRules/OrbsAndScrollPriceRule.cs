namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for item with group 15 or 12, that are orbs and scrolls.
    /// </summary>
    public class OrbsAndScrollPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            if (definition.Value > 0 && (definition.Group == 15 || definition.Group == 12))
            {
                priceCalculation.Price = definition.Value;
                priceCalculation.StopPriceCalculation = true;
            }

            return priceCalculation;
        }
    }
}
