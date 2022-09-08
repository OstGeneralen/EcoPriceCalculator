using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Modules;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using EPC.CommandMod.ChatCommands;
using EPC.Core.Item;
using EPC.Core.Recipe;
using System.Collections.Generic;
using System.Linq;

namespace EPC.CommandMod.EcoWrapper.Types
{
    public class CraftIngredient : ICraftIngredient
    {
        public static User ContextUser { get; set; } = null;
        public static string ContextTableName { get; set; } = "";
        public bool IsTag { get; }
        public string Tag { get; }
        public IGameItem IngredientItem { get; }

        public CraftIngredient(IngredientElement i)
        {
            if (i.IsSpecificItem)
            {
                Tag = string.Empty;
                IngredientItem = new GameItem(i.Item);
                IsTag = false;
            }
            else
            {
                Tag = i.Tag.Name;
                IngredientItem = null;
                IsTag = true;
            }

            _ecoComponent = i;
        }

        public float QuantityRequiredAtTable(ICraftStation station)
        {
            var cc = station as CraftStation;
            var moduleContext = cc.MakeModuleContext(CmdContext.Current.UserHandle);

            if(moduleContext == null)
            {
                return _ecoComponent.Quantity.GetBaseValue;
            }

            return _ecoComponent.Quantity.GetCurrentValue(moduleContext);
        }

        private IngredientElement _ecoComponent;
    }
}
