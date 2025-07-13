using MiraAPI.Events;
using MiraAPI.Events.Vanilla.Gameplay;
using MiraAPI.GameOptions;
using MiraAPI.Modifiers;
using MiraAPI.Utilities;
using Reactor.Utilities;
using TownOfUs.Modifiers.Game.Impostor;
using TownOfUs.Options.Modifiers.Impostor;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfUs.Events.Modifiers;

public static class TelepathEvents
{
    [RegisterEvent]
    public static void AfterMurderEventHandler(AfterMurderEvent @event)
    {
        var source = @event.Source;
        var victim = @event.Target;

        if (PlayerControl.LocalPlayer.HasModifier<TelepathModifier>() && !source.AmOwner && !victim.AmOwner)
        {
            var options = OptionGroupSingleton<TelepathOptions>.Instance;
            if (source.IsImpostor() && source != victim && !MeetingHud.Instance)
            {
                Coroutines.Start(MiscUtils.CoFlash(TownOfUsColors.ImpSoft, alpha: 0.05f));
                var notif1 = Helpers.CreateAndShowNotification(
                    $"<b>{TownOfUsColors.ImpSoft.ToTextColor()}Your teammate, {source.Data.PlayerName}, has killed.</b></color>",
                    Color.white, spr: TouModifierIcons.Telepath.LoadAsset());
                notif1.Text.SetOutlineThickness(0.35f);
                notif1.transform.localPosition = new Vector3(0f, 1f, -20f);
                if (options.KnowKillLocation)
                {
                    victim?.AddModifier<TelepathDeathNotifierModifier>(PlayerControl.LocalPlayer);
                }
            }
            else if (victim.IsImpostor() && options.KnowDeath && !MeetingHud.Instance)
            {
                Coroutines.Start(MiscUtils.CoFlash(TownOfUsColors.ImpSoft, alpha: 0.4f));
                var notif1 = Helpers.CreateAndShowNotification(
                    $"<b>{TownOfUsColors.ImpSoft.ToTextColor()}Your teammate, {victim.Data.PlayerName}, has been murdered!.</b></color>",
                    Color.white, spr: TouModifierIcons.Telepath.LoadAsset());
                notif1.Text.SetOutlineThickness(0.35f);
                notif1.transform.localPosition = new Vector3(0f, 1f, -20f);
                if (options.KnowDeathLocation)
                {
                    victim?.AddModifier<TelepathDeathNotifierModifier>(PlayerControl.LocalPlayer);
                }
            }
        }
    }
}