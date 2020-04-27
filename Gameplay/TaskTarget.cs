using System;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

public class TaskTarget
{
	public string name;
	public int id;
	public NPC npc;
	public int type;
	public string fullName;

	public TaskTarget(string targetName)
	{
		npc = new NPC();
		npc.SetDefaults(NPCID.MossHornet);

		name = "MossHornet";
		id = NPCID.MossHornet;
		//type = npc.type;
		
	}	
}
