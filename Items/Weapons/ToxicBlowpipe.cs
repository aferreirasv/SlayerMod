using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SlayerMod.Items.Weapons
{
    class ToxicBlowpipe : ModItem
    {

        public override void SetDefaults()
        {
            item.damage = 40;
            item.useAmmo = AmmoID.Dart;
            item.UseSound = SoundID.Item17;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.noMelee = true;
            item.crit = 10;
            item.ranged = true;
            item.shoot = 3;
            item.rare = 6;
            item.shootSpeed = 15f;
            item.value = 100000;
            item.autoReuse = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(5,0);
        }


    }
}
