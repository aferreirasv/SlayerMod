using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace SlayerMod.Items.Weapons
{
    public class Claymore : ModItem
    {

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            item.damage = 26;
            item.melee = true;
            item.width = 64;
            item.scale = 1.3f;
            item.height = 64;
            item.useTime = 28;
            item.useStyle = 1;
            item.useAnimation = 28;
            item.rare = 3;
            item.knockBack = 6;
            item.value = 6000;
            item.UseSound = SoundID.Item1;
        }

    }
}
