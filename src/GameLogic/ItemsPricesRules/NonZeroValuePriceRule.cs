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
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            if (definition.Value > 0)
            {
                price = definition.Value * definition.Value * 10 / 12;

                if (item.Definition.Group == 14 && item.Definition.Number <= 8)
                {
                    // Potions + Antidote
                    if (item.Level > 0)
                    {
                        price *= (long)Math.Pow(2, item.Level);
                    }

                    price = price / 10 * 10;
                    price *= item.Durability;
                }

                return new Tuple<long, bool>(price, true);
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
