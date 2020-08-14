namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for item with value greater than 0.
    /// </summary>
    public class NonZeroValuePriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            if (definition.Value > 0)
            {
                priceCalculation.Price = definition.Value * definition.Value * 10 / 12;

                if (item.Definition.Group == 14 && item.Definition.Number <= 8)
                {
                    // Potions + Antidote
                    if (item.Level > 0)
                    {
                        priceCalculation.Price *= (long)Math.Pow(2, item.Level);
                    }

                    priceCalculation.Price = priceCalculation.Price / 10 * 10;
                    priceCalculation.Price *= item.Durability;
                }

                priceCalculation.StopPriceCalculation = true;
            }

            return priceCalculation;
        }
    }
}
