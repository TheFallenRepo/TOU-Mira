using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.Utilities;
using TownOfUs.Roles.Neutral;

namespace TownOfUs.Options.Roles.Neutral;

public sealed class MercenaryOptions : AbstractOptionGroup<MercenaryRole>
{
    public override string GroupName => "Mercenary";

    [ModdedNumberOption("Guard Cooldown", 1f, 15f, 1f, MiraNumberSuffixes.Seconds)]
    public float GuardCooldown { get; set; } = 10f;

    [ModdedNumberOption("Max Number Of Guards", 1f, 5f, 1f, MiraNumberSuffixes.None, "0")]
    public float MaxUses { get; set; } = 3f;

    [ModdedNumberOption("Bribe Cost", 1f, 5f, 1f, MiraNumberSuffixes.None, "0")]
    public float BribeCost { get; set; } = 3f;
}