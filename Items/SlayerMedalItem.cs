
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SlayerMod.Items
{
    public class SlayerMedalItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The currency of Slayers");
        }

        public override void SetDefaults()
        {
            Item refItem = new Item();
            refItem.SetDefaults(ItemID.DefenderMedal);
            item.width = refItem.width;
            item.height = refItem.height;
            item.maxStack = 999;
            item.value = 0;
            item.rare = 3;
        }
    }
}
