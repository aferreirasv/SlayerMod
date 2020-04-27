using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SlayerMod.Gameplay;
using SlayerMod.UI;

namespace SlayerMod.NPCs
{
    class myGlobalNPC : GlobalNPC
    {
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            Splayer splayer = Main.player[projectile.owner].GetModPlayer<Splayer>();
            if (splayer.activeTask != null)
            {
                if (npc.life <= 0 && npc.type == splayer.activeTask.target.type)
                {
                    splayer.activeTask.UpdateProgress();
                    //SlayerUI.UpdateUITask(splayer.activeTask);
                }
            }
            base.OnHitByProjectile(npc, projectile, damage, knockback, crit);
        }

        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            Splayer splayer = player.GetModPlayer<Splayer>();
            if (splayer.activeTask != null)
            {
                if (npc.life <= 0 && npc.type == splayer.activeTask.target.type)
                {
                    splayer.activeTask.UpdateProgress();
                    //SlayerUI.UpdateUITask(splayer.activeTask);
                }
            }

            base.OnHitByItem(npc, player, item, damage, knockback, crit);
        }

    }
}
