using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using static Terraria.ModLoader.ModContent;
using SlayerMod.Items.Boxes;
using Terraria.ID;

namespace SlayerMod.Gameplay
{
    public class BossTask
    {
        public NPC[] targets;
        public string bossName;
        public int reward;
        public TaskTarget target;
        public List<int> targetIDs = new List<int>();
        public TaskTarget[] bosses = new TaskTarget[]
        {
            new TaskTarget(new string[]{"KingSlime"}, bossTarget: true, bossTargetName: "King Slime"),
            new TaskTarget(new string[]{"EyeofCthulhu"}, bossTarget: true, bossTargetName: "Eye Of Cthulhu", targetTier: 1),
            new TaskTarget(new string[]{"EaterofWorldsHead","EaterofWorldsBody","EaterofWorldsTail"}, bossTarget: true, targetTier: 1, bossTargetName: "Eater of Worlds", bossRequiredWorldBiome: "corruption"),
            new TaskTarget(new string[]{"BrainofCthulhu"}, bossTarget: true, targetTier: 1, bossTargetName: "Brain of Cthulhu", bossRequiredWorldBiome: "crimson"),
            new TaskTarget(new string[]{"QueenBee"}, bossTarget: true, targetTier: 1, bossTargetName: "Queen Bee"),
            new TaskTarget(new string[]{"SkeletronHead"}, bossTarget: true, targetTier: 1, bossTargetName:"Skeletron"),
            new TaskTarget(new string[]{"WallOfFlesh"}, bossTarget: true, targetTier: 3, bossTargetName: "Wall of Flesh"),
            new TaskTarget(new string[]{"Spazmatism", "Retinazer" }, bossTarget: true, targetTier: 3, bossTargetName: "The Twins"),
            new TaskTarget(new string[]{"TheDestroyer" }, bossTarget: true, targetTier: 3, bossTargetName: "The Destroyer"),
            new TaskTarget(new string[]{"SkeletronPrime" }, bossTarget: true, targetTier: 3, bossTargetName: "Skeletron Prime"),
            new TaskTarget(new string[]{"Plantera" }, bossTarget: true, targetTier: 4, bossTargetName: "Plantera"),
            new TaskTarget(new string[]{"DukeFishron" }, bossTarget: true, targetTier: 4, bossTargetName: "Duke Fishron"),
            new TaskTarget(new string[]{"Golem" }, bossTarget: true, targetTier: 5, bossTargetName: "Golem"),
            new TaskTarget(new string[]{"DD2DarkMageT1, DD2DarkMageT3" }, bossTarget: true, targetTier: 1, bossTargetName: "Dark Mage"),
            new TaskTarget(new string[]{"DD2OgreT2", "DD2OgreT3" }, bossTarget: true, targetTier: 3, bossTargetName: "Ogre"),
            new TaskTarget(new string[]{"DD2Betsy" }, bossTarget: true, targetTier: 6, bossTargetName: "Betsy"),
            new TaskTarget(new string[]{"MoonLordCore" }, bossTarget: true, targetTier: 6, bossTargetName: "MoonLordCore")

        };
        public BossTask()
        {
            target = SortBoss();
            targets = SetTargets(target);
            reward = SetReward();
        }

        private NPC[] SetTargets(TaskTarget target)
        {
            NPC[] targets = new NPC[target.names.Length];
            int npctype;
            NPC t;
            for (int i = 0; i < targets.Length; i++)
            {
                t = new NPC();
                npctype = NPCID.Search.GetId(target.names[i]);
                t.SetDefaults(npctype);
                targets[i] = t;
                targetIDs.Add(npctype);
            }
            return targets;
        }
        
        private TaskTarget SortBoss()
        {
            Random r = new Random();
            TaskTarget boss = bosses[r.Next(maxValue: bosses.Length)];
            while(boss.Available() == false)
            {
                boss = bosses[r.Next(maxValue: bosses.Length)];
            }
            return boss;
        }

        private int SetReward()
        {
            int reward;
            switch (target.tier)
            {
                case 0:
                    reward = ItemType<SlayerBox>();
                    break;
                case 1:
                    reward = ItemType<WoodenVault>();
                    break;
                case 2:
                    reward = ItemType<WoodenVault>();
                    break;
                case 3:
                    reward = ItemType<SlayerBox>();
                    break;
                case 4:
                    reward = ItemType<SlayerBox>();
                    break;
                case 5:
                    reward = ItemType<SlayerBox>();
                    break;
                case 6:
                    reward = ItemType<SlayerBox>();
                    break;
                case 7:
                    reward = ItemType<SlayerBox>();
                    break;
                default:
                    reward = ItemID.DirtBlock;
                    break;

            }
            return reward;
        }

    }
}
