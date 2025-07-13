using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfUs.Roles.Crewmate;

namespace TownOfUs.Options.Roles.Crewmate;

public sealed class AltruistOptions : AbstractOptionGroup<AltruistRole>
{
    public override string GroupName => "Altruist";

    [ModdedNumberOption("Revive Duration", 1f, 15f, 1f, MiraNumberSuffixes.Seconds)]
    public float ReviveDuration { get; set; } = 5f;

    [ModdedNumberOption("Revive Range", 0.25f, 5f, 0.25f, MiraNumberSuffixes.Multiplier, "0.00")]
    public float ReviveRange { get; set; } = 1f;

    [ModdedNumberOption("Revive Uses", 1f, 5f, 1f, MiraNumberSuffixes.None, "0")]
    public float MaxRevives { get; set; } = 3;

    [ModdedToggleOption("Hide Bodies at Beginning Of Revive")]
    public bool HideAtBeginningOfRevive { get; set; } = false;
}