using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using MiraAPI.GameOptions.OptionTypes;
using MiraAPI.Utilities;
using TownOfUs.Modules.Localization;
using TownOfUs.Roles.Neutral;

namespace TownOfUs.Options.Roles.Neutral;

public sealed class JesterOptions : AbstractOptionGroup<JesterRole>
{
    public override string GroupName => TouLocale.Get(TouNames.Jester, "Jester");

    [ModdedToggleOption("Can Use Button")]
    public bool CanButton { get; set; } = true;

    [ModdedToggleOption("Can Hide In Vents")]
    public bool CanVent { get; set; } = true;

    [ModdedToggleOption("Has Impostor Vision")]
    public bool ImpostorVision { get; set; } = true;

    [ModdedToggleOption("Scatter Mechanic Enabled")]
    public bool ScatterOn { get; set; } = true;

    public ModdedNumberOption ScatterTimer { get; set; } = new("Jester Scatter Timer", 25f, 10f, 60f, 2.5f,
        MiraNumberSuffixes.Seconds, "0.0")
    {
        Visible = () => !OptionGroupSingleton<JesterOptions>.Instance.ScatterOn
    };

    [ModdedEnumOption("After Win Type", typeof(JestWinOptions), ["Ends Game", "Haunts", "Nothing"])]
    public JestWinOptions JestWin { get; set; } = JestWinOptions.EndsGame;
}

public enum JestWinOptions
{
    EndsGame,
    Haunts,
    Nothing
}