using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SlayerMod.Items;
using SlayerMod.Items.Boxes;
using SlayerMod.Items.Weapons;
using SlayerMod.Gameplay;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using SlayerMod;
using SlayerMod.UI;

namespace SlayerMod.NPCs
{
    [AutoloadHead]
    public class Slayer : ModNPC
    {

        public override string Texture => "SlayerMod/NPCs/Slayer";

        public Task activeTask;

        public override bool Autoload(ref string name)
        {
            name = "Slayer";
            return mod.Properties.Autoload;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true; //This defines if the npc is a town Npc or not
            npc.friendly = true;  //this defines if the npc can hur you or not()
            npc.width = 18; //the npc sprite width
            npc.height = 46;  //the npc sprite height
            npc.aiStyle = 7; //this is the npc ai style, 7 is Pasive Ai
            npc.defense = 25;  //the npc defense
            npc.lifeMax = 250;// the npc life
            npc.HitSound = SoundID.NPCHit1;  //the npc sound when is hit
            npc.DeathSound = SoundID.NPCDeath1;  //the npc sound when he dies
            npc.knockBackResist = 0.5f;  //the npc knockback resistance
            Main.npcFrameCount[npc.type] = 25; //this defines how many frames the npc sprite sheet has
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 150; //this defines the npc danger detect range
            NPCID.Sets.AttackType[npc.type] = 3; //this is the attack type,  0 (throwing), 1 (shooting), or 2 (magic). 3 (melee)
            NPCID.Sets.AttackTime[npc.type] = 30; //this defines the npc attack speed
            NPCID.Sets.AttackAverageChance[npc.type] = 10;//this defines the npc atack chance
            NPCID.Sets.HatOffsetY[npc.type] = 4; //this defines the party hat position
            animationType = NPCID.Guide;  //this copy the guide animation
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            //for (int k = 0; k < 255; k++)
            //{
            //    Player player = Main.player[k];
            //    if (!player.active)
            //    {
            //        continue;
            //    }

            //    foreach (Item item in player.inventory)
            //    {
            //        if (item.type == ItemType<ExampleItem>() || item.type == ItemType<Items.Placeable.ExampleBlock>())
            //        {
            //            return true;
            //        }
            //    }
            //}
            //return false;
            return true;
        }

        public static bool TownSpawn()
        {
            //if (Main.hardMode)
            //    return true;
            //else
            return true;

        }

        public static string SetName()
        {
            switch (WorldGen.genRand.Next(8))
            {
                case 0:
                    return "Grizzly Adams";
                case 1:
                    return "Duradel";
                case 2:
                    return "Konar";
                case 3:
                    return "Steve";
                case 4:
                    return "Nieve";
                case 5:
                    return "Chaeldar";
                case 6:
                    return "Krystilia";
                case 7:
                    return "Mazchna";
                default:
                    return "Vannaka";
            }
        }



        public override void SetChatButtons(ref string button, ref string button2)  //Allows you to set the text for the buttons that appear on this town NPC's chat window.
        {
            button = "Shop"; //this defines the buy button name
            button2 = "Task";
            if (Main.LocalPlayer.HasItem(ItemType<BossMedallion>()))
                button2 = "Boss Task";         
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool openShop) //Allows you to make something happen whenever a button is clicked on this town NPC's chat window. The firstButton parameter tells whether the first button or second button (button and button2 from SetChatButtons) was clicked. Set the shop parameter to true to open this NPC's shop.
        {
            Splayer splayer  = SlayerMod.GetModPlayer();
            if (firstButton)
            {
                openShop = true;   //so when you click on buy button opens the shop
            }
            else
            {
                if (Main.LocalPlayer.HasItem(ItemType<BossMedallion>())) 
                {
                    if(splayer.activeBossTask != null)
                    {
                        Main.npcChatText = "What? Are you afraid? GO!!!";
                    }
                    else
                    {
                        splayer.UpdateBossTask(new BossTask());
                        Main.npcChatText = $"I have a special task for you today... I want you to kill {splayer.activeBossTask.target.bossName}. Good Luck.";
                    }





                }
                else
                {

                if (splayer.activeTask != null)
                {
                    if (splayer.activeTask.progress >= splayer.activeTask.quantity)
                    {
                        Main.npcChatText = $"Congratulations, you have completed the task, here's your {splayer.activeTask.reward} medals!";
                        Main.LocalPlayer.QuickSpawnItem(ItemType<SlayerMedalItem>(), splayer.activeTask.reward);
                        splayer.RemoveTask();
                        
                    }
                    else
                    {
                        Main.npcChatText = $"You haven't killed all those {splayer.activeTask.targets[0].FullName}, you've killed only {splayer.activeTask.progress}! Go back there!";
                    }
                }
                else
                {
                    
                    splayer.UpdateTask(new Task());
                    //SlayerUI.UpdateUITask(splayer.activeTask);

                    Main.npcChatText = $"Go kill {splayer.activeTask.quantity} {splayer.activeTask.targets[0].FullName}, {Main.LocalPlayer.name}";

                }
                }
            }
        }

        public override string GetChat()       //Allows you to give this town NPC a chat message when a player talks to it.
        {
            switch (Main.rand.Next(4))    //this are the messages when you talk to the npc
            {
                case 0:
                    return "You wanna buy something?";
                case 1:
                    return "What you want?";
                case 2:
                    {
                        // Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
                        Main.npcChatCornerItem = ItemID.HiveBackpack;
                        return $"Hey, if you find a [i:{ItemID.HiveBackpack}], I can upgrade it for you.";
                    }
                case 3:
                    return "<I'm blue dabu di dabu dai>....OH HELLO THERE..";
                default:
                    return "Go kill Skeletron.";

            }
        }
 

        public override string TownNPCName()
        {
            return Slayer.SetName();
        }

        public override void SetupShop(Chest shop, ref int nextSlot)       //Allows you to add items to this town NPC's shop. Add an item by setting the defaults of shop.item[nextSlot] then incrementing nextSlot.
        {
            ShopItem[] items = new ShopItem[1] 
            { 
                new ShopItem(ItemType<SlayerBox>(),   25, NPC.downedBoss1) // Eye Of Cthulhu
            };

            foreach(ShopItem item in items)
            {
                if (item.Available())
                {
                    shop.item[nextSlot].SetDefaults(item.id);
                    shop.item[nextSlot].shopSpecialCurrency = SlayerMod.SlayerMedalID;
                    shop.item[nextSlot].shopCustomPrice = item.price;
                    nextSlot++;
                }

            }

        }
    }

}