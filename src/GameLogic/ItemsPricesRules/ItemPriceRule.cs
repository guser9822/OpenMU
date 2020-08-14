namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The definition of an item price rule.
    /// </summary>
    public abstract class ItemPriceRule
    {

        private static readonly HashSet<short> WingIds = new HashSet<short>
        {
            0, 1, 2, 3, 4, 5, 6,
            36, 37, 38, 39, 40,
            41, 42, 43, // sum wings
            49, 50, // Rf Capes
            130, 131, 132, 133, 134, 135, // mini wings? -> All worth 240, remove here!
        };

        /// <summary>
        /// Increase the drop level given the level of the item.
        /// <param name="itemLevel">Level of the item.</param>
        /// <param name="dropLevel">Calculated drop level.</param>
        /// </summary>
        /// <returns>Drop level.</returns>
        public int IncreaseDropLevelByItemLevel(byte itemLevel, int dropLevel)
        {
            switch (itemLevel)
            {
                case 5: dropLevel += 4; break;
                case 6: dropLevel += 10; break;
                case 7: dropLevel += 25; break;
                case 8: dropLevel += 45; break;
                case 9: dropLevel += 65; break;
                case 10: dropLevel += 95; break;
                case 11: dropLevel += 135; break;
                case 12: dropLevel += 185; break;
                case 13: dropLevel += 245; break;
                case 14: dropLevel += 305; break;
                case 15: dropLevel += 365; break;
                default:
                    // other levels don't add value.
                    break;
            }

            return dropLevel;
        }

        /// <summary>
        /// Calculate the price of this rule using the item defintion.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <param name="definition">Defintion of the item.</param>
        /// <param name="priceCalculation">Defintion of the current state of the price calculation.</param>
        /// <returns> Return a pair where T1 is the price of the item and T2 state if the calculation of the price should halt. </returns>
        public abstract PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation);

        /// <summary>
        /// State if the item of the type wing/cape.
        /// </summary>
        /// <param name="item">Item.</param>
        /// <returns>true if the item is of type wing/cape, false otherwise</returns>
        protected static bool IsWing(Item item)
        {
            return (item.Definition.Group == 12 && WingIds.Contains(item.Definition.Number))
                   || (item.Definition.Group == 13 && item.Definition.Number == 30); // DL 1st Cape
        }

        /// <summary>
        /// Contains the price calculation information.
        /// </summary>
        public struct PriceCalculation
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PriceCalculation"/> struct.
            /// </summary>
            /// <param name="price">Current price calculated.</param>
            /// <param name="dropLevel">Current drop level calculated.</param>
            /// <param name="stopPriceCalculation">Toggle for halting price calculation.</param>
            public PriceCalculation(long price, int dropLevel, bool stopPriceCalculation = false)
            {
                this.Price = price;
                this.DropLevel = dropLevel;
                this.StopPriceCalculation = stopPriceCalculation;
            }

            /// <summary>
            /// Gets or Sets price.
            /// </summary>
            public long Price { get; set; }

            /// <summary>
            /// Gets or Sets drop level.
            /// </summary>
            public int DropLevel { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether price calculation should halt.
            /// </summary>
            public bool StopPriceCalculation { get; set; }

            /// <summary>
            /// Contains the price calculation information.
            /// </summary>
            /// <returns>A string that represent the price calculation struct.</returns>
            public override string ToString() => $"({this.Price}, {this.DropLevel}, {this.StopPriceCalculation})";
        }
    }
}
