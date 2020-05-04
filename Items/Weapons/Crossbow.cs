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
    public class Crossbow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 20;
            item.noMelee = true;
            item.ranged = true;
            item.width = 50;
            item.height = 30;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.shoot = 3;
            item.shootSpeed = 15f;
            item.UseSound = SoundID.Item5;
            item.rare = 3;
            item.autoReuse = true;
            item.useAmmo = AmmoID.Arrow;
        }




    }
}
