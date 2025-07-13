using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfUs.Roles.Crewmate;

namespace TownOfUs.Options.Roles.Crewmate;

public sealed class OperativeOptions : AbstractOptionGroup<OperativeRole>
{
    public override string GroupName => "Operative";

    [ModdedNumberOption("Starting Vitals Charge", 0f, 100f, 10f, MiraNumberSuffixes.Percent)]
    public float StartingVitalsCharge { get; set; } = 20f;

    [ModdedNumberOption("Starting Security Charge", 0f, 100f, 10f, MiraNumberSuffixes.Percent)]
    public float StartingCamerasCharge { get; set; } = 20f;

    [ModdedNumberOption("Battery Charged Each Round", 0f, 15f, 1f, MiraNumberSuffixes.Percent)]
    public float RoundCharge { get; set; } = 5f;

    [ModdedNumberOption("Battery Charged Per Task", 0f, 15f, 1f, MiraNumberSuffixes.Percent)]
    public float TaskCharge { get; set; } = 5f;

    [ModdedNumberOption("Display Cooldown", 0f, 15f, 1f, MiraNumberSuffixes.Seconds)]
    public float DisplayCooldown { get; set; } = 10f;

    [ModdedNumberOption("Max Display Duration", 0f, 15f, 1f, MiraNumberSuffixes.Seconds)]
    public float DisplayDuration { get; set; } = 10f;
}