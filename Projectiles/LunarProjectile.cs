using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SlayerMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace SlayerMod.Projectiles
{
	public class LunarScimitarProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Scimitar Projectile");
		}


		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.timeLeft = 60;
			projectile.penetrate = 5;
			projectile.timeLeft = 300;
			projectile.alpha = 150;
			projectile.light = 1f;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.tileCollide = true;
			projectile.ignoreWater = true;
			projectile.aiStyle = 0;

		}
		public override void AI()
		{

			projectile.rotation += 0.5f;
			if (projectile.rotation > MathHelper.TwoPi)
			{
				projectile.rotation -= MathHelper.TwoPi;
			}
			else if (projectile.rotation < 0)
			{
				projectile.rotation += MathHelper.TwoPi;
			}



			int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustType<LunarDust>());
			Main.dust[dust].velocity /= 1f;
		}




		public override void Kill(int timeLeft)
		{
			// This code and the similar code above in OnTileCollide spawn dust from the tiles collided with. SoundID.Item10 is the bounce sound you hear.
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item8, projectile.position);
		}
	}
}