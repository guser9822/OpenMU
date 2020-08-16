using System;
using System.Collections.Generic;
using System.Text;

namespace MUnique.OpenMU.DataModel.Configuration.Items
{
    /// <summary>
    /// Define a price rule.
    /// </summary>
    public class ItemPriceRuleDefinition
    {
        /// <summary>
        /// Gets or sets the description of this rule defintion.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the serialized logic expression that represent this rule.
        /// </summary>
        public string SerializedRule { get; set; }

        /// <summary>
        /// Gets or sets the serialized function that used for the price calculation for this rule.
        /// </summary>
        public string SerializedFunction { get; set; }
    }
}
