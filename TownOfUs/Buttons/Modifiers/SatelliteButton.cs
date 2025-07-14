using HarmonyLib;
using MiraAPI.GameOptions;
using MiraAPI.Hud;
using MiraAPI.Modifiers;
using MiraAPI.Utilities;
using MiraAPI.Utilities.Assets;
using TownOfUs.Modifiers.Game.Universal;
using TownOfUs.Options.Modifiers.Universal;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TownOfUs.Buttons.Modifiers;

public sealed class SatelliteButton : TownOfUsButton
{
    public override string Name => "Broadcast";
    public override string Keybind => Keybinds.ModifierAction;
    public override Color TextOutlineColor => TownOfUsColors.Satellite;
    public override float Cooldown => OptionGroupSingleton<SatelliteOptions>.Instance.Cooldown + MapCooldown;
    public override int MaxUses => 1;
    public override ButtonLocation Location => ButtonLocation.BottomLeft;
    public override LoadableAsset<Sprite> Sprite => TouAssets.BroadcastSprite;

    public override bool Enabled(RoleBehaviour? role)
    {
        return PlayerControl.LocalPlayer != null &&
               PlayerControl.LocalPlayer.HasModifier<SatelliteModifier>() &&
               !PlayerControl.LocalPlayer.Data.IsDead;
    }

    public override void CreateButton(Transform parent)
    {
        base.CreateButton(parent);

        Button!.usesRemainingSprite.sprite = TouAssets.AbilityCounterBodySprite.LoadAsset();
    }

    protected override void OnClick()
    {
        var deadBodies = Object.FindObjectsOfType<DeadBody>().ToList();

        deadBodies.Do(x => PlayerControl.LocalPlayer.AddModifier<SatelliteArrowModifier>(x, Color.white));
        if (deadBodies.Count == 0)
        {
            var notif1 = Helpers.CreateAndShowNotification("<b>No bodies were found on the map.</b>", Color.white,
                new Vector3(0f, 1f, -20f), spr: TouModifierIcons.Satellite.LoadAsset());
            notif1.Text.SetOutlineThickness(0.35f);
        }
    }
}