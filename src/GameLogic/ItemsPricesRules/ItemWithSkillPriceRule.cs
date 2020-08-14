namespace MUnique.OpenMU.GameLogic.ItemsPricesRules
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Price rule for item with a skill that is not ForceWaveSkillId.
    /// </summary>
    public class ItemWithSkillPriceRule : ItemPriceRule
    {
        private const short ForceWaveSkillId = 66;

        /// <inheritdoc/>
        public override PriceCalculation CalculatePrice(Item item, ItemDefinition definition, PriceCalculation priceCalculation)
        {
            if (item.HasSkill && definition.Skill?.Number != ForceWaveSkillId)
            {
                priceCalculation.Price += (long)(priceCalculation.Price * 1.5);
            }

            return priceCalculation;
        }
    }
}
