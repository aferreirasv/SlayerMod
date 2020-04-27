using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SlayerMod.Gameplay;

namespace SlayerMod.Gameplay
{
    public class Task
    {

        public NPC target;
        public int type;
        public int quantity;
        public int progress;
        public static string[] monsters = new string[5] { "BlueSlime", "DemonEye", "Zombie", "GreenSlime", "Antlion" };
        public static string[] hardModeMonsters = new string[8] { "Pixie", "WanderingEye", "IceTortoise", "Derpling", "MossHornet", "Wraith", "PossessedArmor", "Arapaima" };


        public Task()
        {
            target = new NPC();
            target.SetDefaults(NPCID.MossHornet);
            type = target.type;
            //target = SortMonster();
            quantity = SortQuantity();
            progress = 0;
        }
        public TaskTarget SortMonster()
        {

            Random r = new Random();
            if (Main.hardMode)
            {
                return new TaskTarget(hardModeMonsters[r.Next(0, 8)]);
            }
            else
            {
                return new TaskTarget(monsters[r.Next(0, monsters.Length)]);
            }
        }


        public int SortQuantity()
        {
            int maxRange = 20;
            Random r = new Random();
            return r.Next(5, maxRange);
        }

        public void UpdateProgress()
        {
            progress++;
        }
    }
}