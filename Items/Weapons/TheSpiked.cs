using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;                      //this are the references that we are going to use
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SlayerMod.Items.Weapons//The directory for your .cs and .png; Example: Mod Sources/TutorialMOD/Items
{
    public class TheSpiked : ModItem    //make sure the sprite file is named like the class name (CustomYoyo)
    {


        public override void SetDefaults()
        {

            item.damage = 60;//The damage stat for the Weapon.
            item.melee = true;     //This defines if it does Melee damage and if its effected by Melee increasing Armor/Accessories.
            item.useTime = 22;  //How fast the Weapon is used.
            item.useAnimation = 22;   //How long the Weapon is used for.
            item.useStyle = 5;//The way your Weapon will be used, 1 is the regular sword swing for example
            item.channel = true;// We can keep the left mouse button down when trying to keep using this weapon.
            item.knockBack = 3f;//The knockback stat of your Weapon.
            item.value = Item.buyPrice(0, 5, 0, 0); //	How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 5;//The color the title of your Weapon when hovering over it ingame   
            item.autoReuse = false;  //Weather your Weapon will be used again after use while holding down, if false you will need to click again after use to use it again.
            item.shoot = mod.ProjectileType("TheSpikedProjectile"); //This defines what type of projectile this weapon will shot	         
            item.noUseGraphic = true; //  Do not use the item graphic when using the item (we just want the yoyo projectile to spawn).
            item.noMelee = true;// Makes sure that the animation when using the item doesn't hurt NPCs.
            item.UseSound = SoundID.Item1; //The sound played when using your Weapon

        }

        // this is how to add a recipe to craft this item

    }
}