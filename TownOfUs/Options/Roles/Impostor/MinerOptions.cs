using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfUs.Roles.Impostor;

namespace TownOfUs.Options.Roles.Impostor;

public sealed class MinerOptions : AbstractOptionGroup<MinerRole>
{
    public override string GroupName => "Miner";

    [ModdedNumberOption("Number Of Miner Vents Per Game", 2f, 15f, 1f, MiraNumberSuffixes.None, "0")]
    public float MaxMines { get; set; } = 5f;

    [ModdedNumberOption("Mine Cooldown", 10f, 60f, 2.5f, MiraNumberSuffixes.Seconds)]
    public float MineCooldown { get; set; } = 25f;

    [ModdedEnumOption("Mine Visiblity", typeof(MineVisiblityOptions), ["Immediate", "After Use"])]
    public MineVisiblityOptions MineVisibility { get; set; } = MineVisiblityOptions.Immediate;

    public ModdedNumberOption MineDelay { get; } = new("Mine Delay", 3f, 0f, 10f, 0.5f, MiraNumberSuffixes.Seconds)
    {
        Visible = () => OptionGroupSingleton<MinerOptions>.Instance.MineVisibility is MineVisiblityOptions.Immediate
    };
}

public enum MineVisiblityOptions
{
    Immediate,
    AfterUse
}