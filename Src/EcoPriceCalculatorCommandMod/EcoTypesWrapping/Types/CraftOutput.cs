using Eco.Gameplay.Items;
using EPC.Core.Item;
using EPC.Core.Recipe;

namespace EPC.CommandMod.EcoWrapper.Types
{
    public class CraftOutput : ICraftOutput
    {
        public IGameItem CraftedItem { get; }
        public float Quantity { get; }

        public CraftOutput(CraftingElement e )
        {
           CraftedItem = new GameItem(e.Item);
           Quantity = e.Quantity.GetBaseValue;
        }
}
}
