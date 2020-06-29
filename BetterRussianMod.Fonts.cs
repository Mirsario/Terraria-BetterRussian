using System.Threading.Tasks;
using ReLogic.Graphics;
using Terraria;

namespace BetterRussian
{
	partial class BetterRussianMod
	{
		private bool hasBackups;
		private DynamicSpriteFont[] combatTextBackup;
		private DynamicSpriteFont deathTextBackup;
		private DynamicSpriteFont itemStackBackup;
		private DynamicSpriteFont mouseTextBackup;

		private void LoadFonts()
		{
			combatTextBackup = Main.fontCombatText;
			deathTextBackup = Main.fontDeathText;
			itemStackBackup = Main.fontItemStack;
			mouseTextBackup = Main.fontMouseText;
			hasBackups = true;

			Main.fontItemStack = GetFont("Fonts/Item_Stack");
			Main.fontMouseText = GetFont("Fonts/Mouse_Text");
			Main.fontDeathText = GetFont("Fonts/Death_Text");
			Main.fontCombatText = new[] {
				GetFont("Fonts/Combat_Text"),
				GetFont("Fonts/Combat_Crit")
			};
		}
		private void UnloadFonts()
		{
			if(!hasBackups) {
				return;
			}

			Main.fontCombatText = combatTextBackup;
			Main.fontDeathText = deathTextBackup;
			Main.fontItemStack = itemStackBackup;
			Main.fontMouseText = mouseTextBackup;

			combatTextBackup = null;
			deathTextBackup = null;
			itemStackBackup = null;
			mouseTextBackup = null;

			hasBackups = false;
		}
	}
}