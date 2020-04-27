using Terraria.ModLoader;
using Terraria;
using SlayerMod.Gameplay;
using Terraria.ID;
using SlayerMod.NPCs;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameInput;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using SlayerMod.UI;



namespace SlayerMod
{
	public class SlayerMod : Mod
	{
		public UserInterface slayerInterface;
		public SlayerUI slayerUI;
		public SlayerMod()
		{
		}
		public override void Load()
		{
			if (!Main.dedServ)
			{
				slayerInterface = new UserInterface();
				slayerUI = new SlayerUI();
				slayerUI.Activate();
				ShowUI();

			}
		}
		public GameTime _lastUpdateUiGameTime;
		public override void UpdateUI(GameTime gameTime)
		{
			_lastUpdateUiGameTime = gameTime;
			if(!Main.gameMenu && slayerInterface?.CurrentState != null)
			{
				slayerInterface.Update(gameTime);
				slayerUI.UpdateText();
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"SlayerMod: slayerInterface",
					delegate
					{
						if (_lastUpdateUiGameTime != null && slayerInterface?.CurrentState != null)
						{
							slayerInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
						}
						return true;
					},
					   InterfaceScaleType.UI));
			}
		}

		public override void MidUpdatePlayerNPC()
		{
			slayerUI.SetPlayer(SlayerMod.GetModPlayer());

		}

		internal void ShowUI()
		{
			slayerInterface.SetState(slayerUI);
		}
		

		internal void HideUI()
		{
			slayerInterface.SetState(null);
		}
		public static Splayer GetModPlayer()
		{
			Player player = Main.player[Main.myPlayer];
			Splayer modPlayer = player.GetModPlayer<Splayer>();
			return modPlayer;
		}
	}

}