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
    class Ak : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("AK-47");
        }
        public override void SetDefaults()
        {
            item.damage = 47;
            item.noMelee = true;
            item.ranged = true;
            item.useAmmo = AmmoID.Bullet;
            item.width = 56;
            item.height = 17;
            item.autoReuse = true;
            item.useAnimation = 8;
            item.useTime = 8;
            item.UseSound = SoundID.Item40;
            item.useStyle = 5;
            item.value = 150000;
            item.rare = 7;
            item.shootSpeed = 50f;
            item.shoot = 3;
            item.knockBack = -5;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10,2);
        }
    }
}
