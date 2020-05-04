using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SlayerMod.Gameplay;

namespace SlayerMod.Gameplay
{
    public class Task
    {

        public NPC[] targets;
        public List<int> targetIDs = new List<int>();
        public TaskTarget sortedTarget;
        public int quantity;
        public int type;
        public int progress;
        public int reward;
        
        public static TaskTarget[] monsters = new TaskTarget[15]
        {

            new TaskTarget(new string[]{"BlueSlime"}),
            new TaskTarget(new string[]{"DemonEye"}),
            new TaskTarget(new string[]{"Zombie", "ZombieElfGirl", "ZombieElf", "ZombiePixie", "ZombieXmas", "ZombieSweater", "ZombieSuperman", "ZombieDoctor", "ZombieElfBeard", "ArmedZombie", "ArmedZombieEskimo", "ArmedZombieSlimed", "ArmedZombieSwamp", "ArmedZombieTwiggy", "ArmedZombieCenx", "ArmedZombiePincussion", "BloodZombie", "SmallFemaleZombie", "BigFemaleZombie", "BigTwiggyZombie", "BigSwampZombie", "SmallSwampZombie", "BigSlimedZombie", "SmallSlimedZombie", "BigPincushionZombie", "SmallPincushionZombie", "BigBaldZombie", "SmallTwiggyZombie", "SmallBaldZombie", "BigRainZombie", "SmallRainZombie", "BigZombie", "SmallZombie", "Zombie", "FemaleZombie", "PincushionZombie", "SwampZombie", "TwiggyZombie", "SlimedZombie", "ZombieMushroom", "ZombieMushroomHat", "ZombieRaincoat", "BaldZombie", "ZombieEskimo"}),
            new TaskTarget(new string[]{"Antlion"}),
            new TaskTarget(new string[]{"Dippler"}),
            new TaskTarget(new string[]{"AngryBones"},     targetTier: 2),
            new TaskTarget(new string[]{"Pixie"},          targetTier: 3),
            new TaskTarget(new string[]{"WanderingEye"},   targetTier: 3),
            new TaskTarget(new string[]{"IceTortoise"},    targetTier: 3,     targetRarity: 2),
            new TaskTarget(new string[]{"Derpling"},       targetTier: 3),
            new TaskTarget(new string[]{"MossHornet"},     targetTier: 3),
            new TaskTarget(new string[]{"PossessedArmor"}, targetTier: 3),
            new TaskTarget(new string[]{"Arapaima"},       targetTier: 3),
            new TaskTarget(new string[]{"Wraith"},         targetTier: 3),
            new TaskTarget(new string[]{"DrMainFly"},      targetTier: 5),
        };
        

        public Task()
        {

            sortedTarget = SortMonster();
            targets = SetTargets(sortedTarget);
            quantity = SortQuantity();
            progress = 0;
            reward = calculateReward();
        }

        private NPC[] SetTargets(TaskTarget sortedTarget)
        {
            NPC[] targets = new NPC[sortedTarget.names.Length];
            int npctype;
            NPC t;
            for (int i = 0; i < targets.Length; i++)
            {
                t = new NPC();
                npctype = NPCID.Search.GetId(sortedTarget.names[i]);
                t.SetDefaults(npctype);
                targetIDs.Add(npctype);
                targets[i] = t;
            }
            return targets;
        }

        public TaskTarget SortMonster()
        {
            TaskTarget t = monsters[Main.rand.Next(monsters.Length)];
            while (t.Available() == false)
            {
                t = monsters[Main.rand.Next(monsters.Length)];
            }
            return t;
        }


        public int calculateReward()
        {
            return (quantity / 3) * (sortedTarget.rarity);
        }
        public int SortQuantity()
        {
            int maxConst = 25;
            int maxRange = maxConst / (sortedTarget.rarity);
            int minRange = maxRange / 2;
            Random r = new Random();
            return r.Next(minRange, maxRange);
        }

        public void UpdateProgress()
        {
            progress++;
        }
    }
}