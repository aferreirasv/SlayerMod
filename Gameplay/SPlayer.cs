using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using SlayerMod.Gameplay;


namespace SlayerMod.Gameplay
{
	public class Splayer : ModPlayer
	{
		public Task activeTask = null;
		public BossTask activeBossTask = null;

		public Splayer()
		{
		}

		public Task GetTask()
		{
			return activeTask;
		}

		public BossTask GetBossTask()
		{
			return activeBossTask;
		}

		//public void OnHitNPC(NPC target)
  //      {
		//	if(activeTask != null)
  //          {
		//		if (target.life <= 0 && activeTask.targetIDs.Contains(target.type))
  //              {
		//			activeTask.UpdateProgress();
  //              }
  //          }
  //      }

		public void UpdateTask(Task task)
        {
			this.activeTask = task;
        }

		public void UpdateBossTask(BossTask task)
		{
			this.activeBossTask = task;
		}

		public void RemoveBossTask()
		{
			activeBossTask = null;
		}
		public void RemoveTask()
        {
			activeTask = null;
        }
	}	
}
