using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace BetterRussian
{
	public partial class BetterRussianMod : Mod
	{
		private TaskCompletionSource<bool> unloadTCS;

		public override void Load()
		{
			if(Main.dedServ) {
				return;
			}

			LoadFonts();

			Main.OnPreDraw += PreDraw;
		}
		public override void Unload()
		{
			if(Main.dedServ) {
				return;
			}

			unloadTCS = new TaskCompletionSource<bool>();

			unloadTCS.Task.Wait(); //Graphics have to be unloaded in PreDraw on the main thread, otherwise they may get unloaded as they're used.

			Main.OnPreDraw -= PreDraw;
		}

		private void PreDraw(GameTime obj)
		{
			if(unloadTCS!=null) {
				UnloadGraphics();

				unloadTCS.SetResult(true);

				unloadTCS = null;
			}
		}
		private void UnloadGraphics()
		{
			UnloadFonts();
		}
	}
}