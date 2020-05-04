using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using SlayerMod.Items.Weapons;

namespace SlayerMod.Items.Boxes
{
    class SteelVault : ModItem
    {

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("<right> for rewards!");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 5;
            item.maxStack = 30;
            item.value = 20000;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            BoxItem drop = GetDrops();
            player.QuickSpawnItem(drop.id);
        }


        private BoxItem GetDrops()
        {
            Random r = new Random();
            BoxItem[] drops = new BoxItem[3]
            {
                new BoxItem(ItemType<TheSpiked>()),
                new BoxItem(ItemType<FineCrossbow>()),
                new BoxItem(ItemType<TridentOfSeas>()),

            };

            return drops[r.Next(0, drops.Length)];

        }
    }
}
