using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SlayerMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace SlayerMod.Projectiles
{
	public class LunarProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Projectile");
		}


		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 60;
			projectile.penetrate = 2;
			projectile.timeLeft = 300;
			projectile.alpha = 150;
			projectile.light = 0.5f;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 18;
			projectile.damage = 69;

		}

	
		//public override void Kill(int timeLeft)
		//{
		//	// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
		//	Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
		//	Main.PlaySound(SoundID.Item8, projectile.position);
		//}
	}	
}