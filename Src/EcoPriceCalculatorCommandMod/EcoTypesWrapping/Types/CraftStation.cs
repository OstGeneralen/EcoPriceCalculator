using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Players;
using EPC.Core.Recipe;

namespace EPC.CommandMod.EcoWrapper.Types
{
    public class CraftStation : ICraftStation
    {
        public string StationInstanceName { get => _internalComponent.Parent.Name; }
        public string StationTypeName { get => _internalComponent.Parent.DisplayName; }

        public CraftStation(CraftingComponent component)
        {
            _internalComponent = component;
        }

        public float GetQuantityRequired(ICraftIngredient ingredient)
        {
            return ingredient.QuantityRequiredAtTable(this);
        }

        public ModuleContext? MakeModuleContext(User user)
        {
            if(_internalComponent.ResourceEfficiencyModule == null)
            {
                return null;
            }

            return new ModuleContext(user, _internalComponent.Parent.Position, _internalComponent.ResourceEfficiencyModule);
        }

        private CraftingComponent _internalComponent;
    }
}
