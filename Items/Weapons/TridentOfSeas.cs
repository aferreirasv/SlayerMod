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
    public class TridentOfSeas : ModItem
    {

        public override void SetDefaults()
        {
            item.noMelee = true;
            item.useStyle = 5;
            item.damage = 42;
            item.width = 50;
            item.height = 50;
            item.UseSound = SoundID.Item8;
            item.useTime = 25;
            item.magic = true;
            item.autoReuse = true;
            item.channel = true;
            item.mana = 4;
            item.rare = 5;
            item.useAnimation = 7;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("TridentOfSeasProjectile");
        }

        //public override void HoldItem(Player player)
        //{
        //    float angle = player.AngleTo(new Vector2(Main.mouseX, Main.mouseY));
        //    player.itemRotation = -45f + angle;

        //}
    }
}
