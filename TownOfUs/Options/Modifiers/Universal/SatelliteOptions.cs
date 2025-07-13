using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfUs.Modifiers.Game.Universal;
using UnityEngine;

namespace TownOfUs.Options.Modifiers.Universal;

public sealed class SatelliteOptions : AbstractOptionGroup<SatelliteModifier>
{
    public override string GroupName => "Satellite";
    public override uint GroupPriority => 27;
    public override Color GroupColor => TownOfUsColors.Satellite;

    [ModdedNumberOption("Button Cooldown", 5f, 15f, 1f, MiraNumberSuffixes.Seconds)]
    public float Cooldown { get; set; } = 10f;
}