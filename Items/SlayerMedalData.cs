using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.UI;


namespace SlayerMod.Items
{
    public class SlayerMedalData : CustomCurrencySingleCoin
    {
        public Color SlayerMedalTextColor = Color.DarkRed;

        public SlayerMedalData(int coinItemID, long currencyCap) : base(coinItemID, currencyCap)
        {

        }

        public override void GetPriceText(string[] lines, ref int currentLine, int price)
        {
            Color color = SlayerMedalTextColor * ((float)Main.mouseTextColor / 255f);
            lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
                {
                    color.R,
                    color.G,
                    color.B,
                    Lang.tip[50],
                    price,
                    "Slayer Medal" //this is the Currency name when shown in the shop
                });
        }
    }
}
