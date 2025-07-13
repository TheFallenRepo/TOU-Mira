using MiraAPI.GameOptions;
using MiraAPI.GameOptions.Attributes;
using TownOfUs.Roles.Neutral;

namespace TownOfUs.Options.Roles.Neutral;

public sealed class PhantomOptions : AbstractOptionGroup<PhantomTouRole>
{
    public override string GroupName => "Phantom";

    [ModdedNumberOption("Tasks Left Before Clickable", 1, 15)]
    public float NumTasksLeftBeforeClickable { get; set; } = 5f;

    [ModdedEnumOption("Phantom Win", typeof(PhantomWinOptions), ["Ends Game", "Nothing"])]
    public PhantomWinOptions PhantomWin { get; set; } = PhantomWinOptions.Nothing;
}

public enum PhantomWinOptions
{
    EndsGame,
    Nothing
}