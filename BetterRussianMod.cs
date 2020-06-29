using Terraria.ModLoader;

namespace BetterRussian
{
	public partial class BetterRussianMod : Mod
	{
		public override void Load() => LoadFonts();
		public override void Unload() => UnloadFonts();
	}
}