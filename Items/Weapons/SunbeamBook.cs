using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SlayerMod.Items.Weapons
{
    class SunbeamBook : ModItem
    {

        public override void SetDefaults()
        {
            item.damage = 7;
            item.noMelee = true;
            item.noUseGraphic = false;
            item.magic = true;
            item.channel = true;
            item.mana = 5;
            item.rare = 3;
            item.width = 28;
            item.height = 30;
            item.useTime = 7;
            item.UseSound = SoundID.Item60;
            item.useStyle = 5;
            item.shootSpeed = 4f;
            item.useAnimation = 7;
            item.shoot = mod.ProjectileType("SunbeamProjectile");
            item.value = 10000;
        }
    }
}
