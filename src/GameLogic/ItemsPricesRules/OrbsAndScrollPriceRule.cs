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
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            if (definition.Value > 0 && (definition.Group == 15 || definition.Group == 12))
            {
                return new Tuple<long, bool>(definition.Value, true);
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
