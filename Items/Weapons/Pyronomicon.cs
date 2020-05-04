using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace SlayerMod.Items.Weapons
{
    class Pyronomicon : ModItem
    {
        public override void SetDefaults()
        {
            item.noMelee = true;
            item.magic = true;
            item.damage = 50 ;
            item.mana = 4;
            item.useAnimation = 7;
            item.useTime = 7;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("PyronomiconProj");
            item.shootSpeed = 10f;
            item.rare = 5;
            item.value = 50000;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.channel = true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(4, 4);
        }

    }
}
