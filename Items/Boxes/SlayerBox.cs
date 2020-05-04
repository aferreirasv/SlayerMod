using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace SlayerMod.Items.Boxes 
{
    class SlayerBox : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slayer's Box");
            Tooltip.SetDefault("<right> for rewards!");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.rare = 2;
            item.maxStack = 30;
            item.value = 10000;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            List<BoxItem> drops = GetDrops();
            foreach(BoxItem drop in drops)
            {
                player.QuickSpawnItem(drop.id, drop.stack);
            }
        }


        private List<BoxItem> GetDrops()
        {
            Random r = new Random();
            int[] phaseBlades = new int[] { ItemID.BluePhaseblade, ItemID.RedPhaseblade, ItemID.GreenPhaseblade };
            BoxItem[] common = new BoxItem[4]
            {
                new BoxItem(ItemID.IronBar,         5,      15),
                new BoxItem(ItemID.BattlePotion,            max: 2),
                new BoxItem(ItemID.SilverCoin,      10,     60),
                new BoxItem(ItemID.LeadBar,         5,      15)
            };
            BoxItem[] rare = new BoxItem[10]
            {
                new BoxItem(ItemID.GrapplingHook),
                new BoxItem(ItemID.TallyCounter),
                new BoxItem(ItemID.Katana),
                new BoxItem(ItemID.Handgun),
                new BoxItem(ItemID.SlimeStaff),
                new BoxItem(ItemID.SapphireStaff),
                new BoxItem(ItemID.RedCape),
                new BoxItem(ItemID.GoldCoin,        1,      3),
                new BoxItem(ItemType<BossMedallion>()),
                new BoxItem(phaseBlades[r.Next(0,phaseBlades.Length)])
            };
            BoxItem[] legendary = new BoxItem[3]
            {
                new BoxItem(ItemID.EnchantedSword),
                new BoxItem(ItemID.Arkhalis),
                new BoxItem(ItemID.CelestialMagnet)
            };
            
            List<BoxItem> drops = new List<BoxItem>();

            BoxItem common1 = common[r.Next(0, common.Length)];
            BoxItem common2 = common[r.Next(0, common.Length)];
            while(common2 == common1)
            {
               common2 = common[r.Next(0, common.Length)];
            }
            
            
            BoxItem rareDrop = rare[r.Next(0, rare.Length)];
            if (rareDrop.id == ItemID.Handgun)
            {
                drops.Add(new BoxItem(ItemID.MusketBall, 100,100));
            }

            int hasLegendary = r.Next(0, 100);
            if (hasLegendary >= 95)
            {
                BoxItem legendaryDrop = legendary[r.Next(0, legendary.Length)];
                drops.Add(legendaryDrop);
            }
            
            drops.Add(common1);
            drops.Add(common2);
            drops.Add(rareDrop);
            return drops;

        }
    }
}
