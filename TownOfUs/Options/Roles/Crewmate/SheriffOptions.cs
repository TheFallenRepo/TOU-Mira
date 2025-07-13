using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfUs.Modules.Localization;
using TownOfUs.Roles.Crewmate;

namespace TownOfUs.Options.Roles.Crewmate;

public sealed class SheriffOptions : AbstractOptionGroup<SheriffRole>
{
    public override string GroupName => TouLocale.Get(TouNames.Sheriff, "Sheriff");

    [ModdedNumberOption("Kill Cooldown", 10f, 60f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float KillCooldown { get; set; } = 25f;

    [ModdedToggleOption("Sheriff Can Report Who They've Killed")]
    public bool SheriffBodyReport { get; set; } = true;

    [ModdedToggleOption("Allow Shooting in First Round")]
    public bool FirstRoundUse { get; set; } = false;

    [ModdedToggleOption("Can Shoot Neutral Evil Roles")]
    public bool ShootNeutralEvil { get; set; } = false;

    [ModdedToggleOption("Can Shoot Neutral Killing Roles")]
    public bool ShootNeutralKiller { get; set; } = false;

    [ModdedEnumOption("Misfire Kills", typeof(MisfireOptions), ["Self", "Target", "Self & Target", "No One"])]
    public MisfireOptions MisfireType { get; set; } = MisfireOptions.Sheriff;
}

public enum MisfireOptions
{
    Sheriff,
    Target,
    Both,
    Nobody
}