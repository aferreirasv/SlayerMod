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
    public class FineCrossbow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 46;
            item.noMelee = true;
            item.ranged = true;
            item.width = 50;
            item.height = 30;
            item.useTime = 18;
            item.useAnimation = 30;
            item.useStyle = 5;
            item.shoot = 3;
            item.shootSpeed = 23f;
            item.UseSound = SoundID.Item5;
            item.rare = 5;
            item.autoReuse = true;
            item.knockBack = 2.5f;
            item.useAmmo = AmmoID.Arrow;
            item.value = 50000;
        }




    }
}
