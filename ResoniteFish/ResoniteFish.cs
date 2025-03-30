
using System;

using Elements.Core;
using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace ResoniteFish;
public class ResoniteFish : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0";
	public override string Name => "Fish";
	public override string Author => "Delta";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/XDelta/ResoniteFish";

	public override void OnEngineInit() {
		Harmony harmony = new("net.deltawolf.Fish");
		harmony.PatchAll();
	}

	[HarmonyPatch(typeof(InteractionHandler), "OpenContextMenu")]
	private class ContextMenuOpenMenuAPatch {
		public static void Postfix(InteractionHandler __instance, InteractionHandler.MenuOptions options) {
			ContextMenu ctx = __instance.ContextMenu;
			if (options == InteractionHandler.MenuOptions.Default) {
				ctx.AddItem("Fish", new Uri("resdb:///5a56714e4cc021888cb51162cc34b55a7a1333fe8bc162c8be906f9345206b3c.png"), colorX.Cyan);
			}
		}
	}
}
