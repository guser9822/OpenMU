namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
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
        private static readonly HashSet<short> WingIds = new HashSet<short>
        {
            0, 1, 2, 3, 4, 5, 6,
            36, 37, 38, 39, 40,
            41, 42, 43, // sum wings
            49, 50, // Rf Capes
            130, 131, 132, 133, 134, 135, // mini wings? -> All worth 240, remove here!
        };

        /// <inheritdoc/>
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            dropLevel = this.IncreaseDropLevelByItemLevel(item.Level, dropLevel);

            // Wings
            if (IsWing(item))
            {
                // maybe we have to exclude small wings here
                price = ((dropLevel + 40) * dropLevel * dropLevel * 11) + 40000000;
            }
            else
            {
                // This is " not a wing" price rule, It could be moved into another rule
                price = ((dropLevel + 40) * dropLevel * dropLevel / 8) + 100;
            }

            return new Tuple<long, bool>(price, false);
        }

        private static bool IsWing(Item item)
        {
            return (item.Definition.Group == 12 && WingIds.Contains(item.Definition.Number))
                   || (item.Definition.Group == 13 && item.Definition.Number == 30); // DL 1st Cape
        }

    }
}
