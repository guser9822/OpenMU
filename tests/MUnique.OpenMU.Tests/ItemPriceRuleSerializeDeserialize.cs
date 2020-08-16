// <copyright file="AppearanceSerializerTest.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Moq;
    using MUnique.OpenMU.AttributeSystem;
    using MUnique.OpenMU.DataModel.Configuration;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;
    using MUnique.OpenMU.GameLogic.Attributes;
    using MUnique.OpenMU.GameLogic.ItemsPricesRules;
    using MUnique.OpenMU.GameServer.RemoteView;
    using NUnit.Framework;
    using Serialize.Linq.Extensions;
    using Serialize.Linq.Serializers;
    using static MUnique.OpenMU.GameLogic.ItemsPricesRules.ItemPriceRule;

    /// <summary>
    /// Tests the <see cref="ItemPriceRuleSerializeDeserialize"/>.
    /// </summary>
    [TestFixture]
    public class ItemPriceRuleSerializeDeserialize
    {
        /// <summary>
        /// Tests if a new (naked) dark knight with small axe would be serialized correctly.
        /// </summary>
        [Test]
        public void ShieldOrOneHandedPriceRules()
        {
            var itmDef = new Mock<ItemDefinition>();
            itmDef.SetupAllProperties();
            itmDef.Setup(d => d.BasePowerUpAttributes).Returns(new List<ItemBasePowerUpDefinition>());
            itmDef.Object.Group = 2;
            itmDef.Object.Width = 1;

            var powUpDef = new Mock<ItemBasePowerUpDefinition>();
            powUpDef.SetupAllProperties();
            powUpDef.Object.TargetAttribute = Stats.MinimumPhysBaseDmg;

            itmDef.Object.BasePowerUpAttributes.Add(powUpDef.Object);
            ItemDefinition oneHandedDef = itmDef.Object;

            var itmDef2 = new Mock<ItemDefinition>();
            itmDef2.SetupAllProperties();
            itmDef2.Object.Group = 6;
            ItemDefinition shieldDef = itmDef2.Object;

            // Define expression for verifying that the item is a shield or a one handed
            Expression<Func<ItemDefinition, bool>> isOneHanded = itemDef => (itemDef.Group < 6 && itemDef.Width < 2 && itemDef.BasePowerUpAttributes.Any(o => o.TargetAttribute == Stats.MinimumPhysBaseDmg));
            Expression<Func<ItemDefinition, bool>> isShield = itemDef => itemDef.Group == 6;

            var argument = Expression.Parameter(typeof(ItemDefinition), "itemDef");
            Expression<Func<ItemDefinition, bool>> isShieldOrOneHandedExpression = Expression.Lambda<Func<ItemDefinition, bool>>(
                    Expression.Or(isOneHanded.Body, isShield.Body),
                    new[] { argument });

            // Define expression for price calculation
            long price = 1L;
            PriceCalculation priceCalcObj = new ItemPriceRule.PriceCalculation{ Price = price };
            Expression<Func<ItemPriceRule.PriceCalculation, long>> priceCalculationExpression = priceCalc => priceCalc.Price * 80 / 100;

            //// Serialize expressions
            var serializer = new ExpressionSerializer(new JsonSerializer());
            serializer.AddKnownType(typeof(AttributeDefinition)); // for isShieldOrOneHandedExpression

            string serIsShieldOrOneHandedExpr = serializer.SerializeText(isShieldOrOneHandedExpression);
            string serPriceCalcExpr = serializer.SerializeText(priceCalculationExpression);

            //// Deserialize expressions
            Expression<Func<ItemDefinition, bool>> deserIsShieldOrOneHandedExpr = (Expression<Func<ItemDefinition, bool>>)serializer.DeserializeText(serIsShieldOrOneHandedExpr);
            var compilIsShieldOrOneHandedExpr = deserIsShieldOrOneHandedExpr.Compile();

            Expression<Func<ItemPriceRule.PriceCalculation, long>> deserPriceCalcExpr = (Expression<Func<ItemPriceRule.PriceCalculation, long>>)serializer.DeserializeText(serPriceCalcExpr);
            var compilPriceCalcExpr = deserPriceCalcExpr.Compile();

            var isOndedItem = compilIsShieldOrOneHandedExpr.Invoke(oneHandedDef);
            var isShieldItem = compilIsShieldOrOneHandedExpr.Invoke(shieldDef);
            var calculatedPrice = compilPriceCalcExpr.Invoke(priceCalcObj);

            Assert.That(isOndedItem, Is.True);
            Assert.That(isShieldItem, Is.True);
            Assert.That(calculatedPrice, Is.EqualTo(price * 80 / 100));
        }
    }
}
