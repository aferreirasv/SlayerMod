using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.UI;
using Terraria.ModLoader;
using SlayerMod.Gameplay;
using SlayerMod.NPCs;


namespace SlayerMod.UI
{
    public class UISlayerDisplay : UIElement
    {
        private static Task activeTask;
        public UISlayerDisplay()
        {
            Width.Set(100, 0f);
            Height.Set(40, 0f);
        }

        public static void DisplayTask(Task task)
        {
            UISlayerDisplay.activeTask = task;
        }
        public static void RemoveTask()
        {
            UISlayerDisplay.activeTask = null;
        }


        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle innerDimensions = GetInnerDimensions();
            base.DrawSelf(spriteBatch);
            float shopx = innerDimensions.X;
            float shopy = innerDimensions.Y;

            Utils.DrawBorderStringFourWay(spriteBatch, Main.fontItemStack, $"{activeTask.progress}/{activeTask.quantity}", shopx, shopy, Color.White, Color.White, new Vector2(0.3f), 0.75f);
            
        }




    }
}
