using Eco.Gameplay.Items;
using EPC.Core.Item;
using System.Collections.Generic;

namespace EPC.CommandMod.EcoWrapper.Types
{
    public class GameItem : IGameItem
    {
        public int ID { get; }
        public string DisplayName { get; }
        public IEnumerable<string> Tag { get; }

        public GameItem(Item item)
        {
            ID = item.TypeID;
            DisplayName = item.DisplayName;
            Tag = item.TagNames();
        }
    }
}
