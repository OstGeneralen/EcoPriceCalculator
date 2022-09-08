using Eco.Gameplay.Items;
using EPC.Core.Recipe;
using System.Collections.Generic;

namespace EPC.CommandMod.EcoWrapper.Types
{
    public class CraftRecipe : ICraftRecipe
    {
        public IEnumerable<ICraftOutput> Outputs { get; }
        public IEnumerable<ICraftIngredient> Ingredients { get; }
        public float Time { get => 0.0f; }
        public float Labour { get => 0.0f; }
        public string ReadableName { get; }
        public string TableName { get; }


        public CraftRecipe(RecipeFamily r)
        {
            ReadableName = r.DisplayName;

            TableName = r.CraftingTable.DisplayName;

            var craftOutputList = new List<CraftOutput>();

            foreach(var ro in r.Product)
            {
                craftOutputList.Add(new CraftOutput(ro));
            }

            var craftInputList = new List<CraftIngredient>();

            foreach(var ri in r.Ingredients)
            {
                craftInputList.Add(new CraftIngredient(ri));
            }

            Outputs = craftOutputList;
            Ingredients = craftInputList;
        }

    }
}
