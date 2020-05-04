using System;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class TaskTarget
{
	public string[] names;
	public string bossName;
	private static bool[] conditions = new bool[8]
	{
		true,
		NPC.downedBoss1, //Eye of Claudinho
 		NPC.downedBoss3, // Skeletron
		Main.hardMode, //Wall of Flesh
		NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3, //All Mech Boss
		NPC.downedPlantBoss, //Plantera
 		NPC.downedGolemBoss, //Golem
		NPC.downedMoonlord //Moon Lord
	};
	public int rarity;
	public int tier;
	public bool boss;
	public string biome;



	public TaskTarget(string[] targetNames, int targetTier = 0, int targetRarity = 1, bool bossTarget = false, string bossTargetName = "", string bossRequiredWorldBiome = "")
	{
		names = targetNames;
		tier = targetTier;
		rarity = targetRarity;
		boss = bossTarget;
		bossName = bossTargetName;
		biome = bossRequiredWorldBiome;
	}	
	

	public bool Available()
	{
		bool biomeCondition = true;
		if(biome != "")
		{

			if(biome == "crimson")
			{
				biomeCondition = WorldGen.crimson;
			}
			else if(biome == "corruption")
			{
				biomeCondition = !WorldGen.crimson;
			}
			else
			{
				biomeCondition = false;
			}
		}
		return conditions[tier] && biomeCondition;
		
	}
}
