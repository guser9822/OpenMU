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
        public override Tuple<long, bool> CalculatePrice(Item item, ItemDefinition definition, int dropLevel, long price)
        {
            if (item.HasSkill && definition.Skill?.Number != ForceWaveSkillId)
            {
                price += (long)(price * 1.5);
            }

            return new Tuple<long, bool>(price, false);
        }
    }
}
