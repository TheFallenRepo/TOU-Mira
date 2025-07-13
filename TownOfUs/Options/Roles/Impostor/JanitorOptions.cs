using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfUs.Roles.Impostor;

namespace TownOfUs.Options.Roles.Impostor;

public sealed class JanitorOptions : AbstractOptionGroup<JanitorRole>
{
    public override string GroupName => "Janitor";

    [ModdedNumberOption("Clean Uses Per Game", 1f, 15f, 1f, MiraNumberSuffixes.None, "0")]
    public float MaxClean { get; set; } = 5f;

    [ModdedNumberOption("Clean Cooldown", 10f, 60f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float CleanCooldown { get; set; } = 25f;

    [ModdedNumberOption("Clean Delay", 0f, 15f, 1f, MiraNumberSuffixes.Seconds)]
    public float CleanDelay { get; set; } = 5f;

    [ModdedToggleOption("Reset Kill & Clean Cooldowns Together")]
    public bool ResetCooldowns { get; set; } = true;
}