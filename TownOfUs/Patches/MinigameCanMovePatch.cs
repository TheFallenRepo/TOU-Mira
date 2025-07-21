using HarmonyLib;
using MiraAPI.Hud;
using TownOfUs.Roles.Crewmate;
using TownOfUs.Roles.Neutral;

namespace TownOfUs.Patches;

[HarmonyPatch]
public static class MinigameCanMovePatch
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CanMove), MethodType.Getter)]
    [HarmonyPrefix]
    public static bool PlayerControlCanMovePatch(PlayerControl __instance, ref bool __result)
    {
        if (PlayerControl.LocalPlayer == null)
        {
            return true;
        }

        if (MeetingHud.Instance)
        {
            return true;
        }

        if (ActiveInputManager.currentControlType == ActiveInputManager.InputType.Keyboard && Minigame.Instance is CustomPlayerMenu && (PlayerControl.LocalPlayer.Data.Role is TransporterRole || PlayerControl.LocalPlayer.Data.Role is GlitchRole))
        {
            __result = __instance.moveable;
            return false;
        }

        return true;
    }
}