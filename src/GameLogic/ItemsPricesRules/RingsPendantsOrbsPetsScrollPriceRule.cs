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
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            if ((item.Definition.Group == 12 && item.Definition.Number > 6) || item.Definition.Group == 13 || item.Definition.Group == 15)
            {
                price = (dropLevel * dropLevel * dropLevel) + 100;
                return new Tuple<long, bool>(price, true);
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
