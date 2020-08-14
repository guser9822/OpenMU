namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;
    using MUnique.OpenMU.GameLogic.Attributes;

    /// <summary>
    /// Price for shields or one handed items.
    /// </summary>
    public class ShieldOrOneHandedPriceRule : ItemPriceRule
    {
        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            var isOneHandedWeapon = item.Definition.Group < 6 && definition.Width < 2 && definition.BasePowerUpAttributes.Any(o => o.TargetAttribute == Stats.MinimumPhysBaseDmg);
            var isShield = item.Definition.Group == 6;
            if (isOneHandedWeapon || isShield)
            {
                priceCalculation.Price = priceCalculation.Price * 80 / 100;
            }

            return priceCalculation;
        }
    }
}
