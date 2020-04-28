using System;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class TaskTarget
{
	public string []names;
	private static bool[] conditions = new bool[8]
	{
		true,
		NPC.downedBoss1, //Eye of Claudinho
 		NPC.downedBoss3, // Skeletron
		Main.hardMode, //Wall of Flesh
		NPC.downedMechBossAny, //Any Mech Boss
		NPC.downedPlantBoss, //Plantera
 		NPC.downedGolemBoss, //Golem
		NPC.downedMoonlord //Moon Lord
	};
	public int rarity;
	public int tier;


	public TaskTarget(string []targetNames, int targetTier = 0, int targetRarity = 1)
	{
		names = targetNames;
		tier = targetTier;
		rarity = targetRarity;
	}	

	public bool Available()
	{
		return conditions[tier];
	}
}
