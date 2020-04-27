using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using SlayerMod.Gameplay;
using Terraria.GameContent.UI.Elements;

namespace SlayerMod.UI
{
    public class SlayerUI : UIState
    {
        public DraggableUIPanel SlayerPanel;
        public UISlayerDisplay SlayerDisplay;
        public static bool visible = false;
        Splayer splayer;

        UIText progress;
        UIText target;

        public override void OnInitialize()
        {
            SlayerPanel = new DraggableUIPanel();
            SlayerPanel.SetPadding(2);
            SlayerPanel.Left.Set(1100, 0f);
            SlayerPanel.Top.Set(350, 0f);
            SlayerPanel.Width.Set(200, 0);
            
            SlayerPanel.BackgroundColor = new Color(73, 94, 171);

            Append(SlayerPanel);

            target = new UIText("");
            progress = new UIText($"No Active Task");
            target.Left.Set(20, 0);
            target.Top.Set(20, 0);


            SlayerPanel.Append(progress);
            SlayerPanel.Append(target);
            
        }


        public void UpdateText()
        {
            if (splayer?.activeTask != null)
            {
                progress.Left.Set(20, 0);
                progress.Top.Set(50, 0);
                SlayerPanel.Height.Set(90, 0);
                target.SetText($"- {splayer.activeTask.target.FullName}");
                progress.SetText($"- {splayer.activeTask.progress}/{splayer.activeTask.quantity}");
            }
            else
            {
                progress.Left.Set(20, 0);
                progress.Top.Set(20, 0);
                SlayerPanel.Height.Set(60, 0);
                target.SetText("");
                progress.SetText("- No active tasks.");
            }
        }
        public void SetPlayer(Splayer modPlayer)
        {
            splayer = modPlayer;
        }
    }
}