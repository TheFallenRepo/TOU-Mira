using System.Text;
using Il2CppInterop.Runtime.Attributes;
using MiraAPI.Roles;
using TownOfUs.Modules.Wiki;
using TownOfUs.Utilities;
using UnityEngine;

namespace TownOfUs.Roles.Crewmate;

public sealed class OperativeRole(IntPtr cppPtr) : CrewmateRole(cppPtr), ITownOfUsRole, IWikiDiscoverable, IDoomable
{
    public override bool IsAffectedByComms => false;
    public DoomableType DoomHintType => DoomableType.Insight;
    public string RoleName => "Operative";
    public string RoleDescription => "Hack The System";
    public string RoleLongDescription => "Use vitals and cameras from anywhere on the map";
    public Color RoleColor => TownOfUsColors.Operative;
    public ModdedRoleTeams Team => ModdedRoleTeams.Crewmate;
    public RoleAlignment RoleAlignment => RoleAlignment.CrewmateInvestigative;

    public CustomRoleConfiguration Configuration => new(this)
    {
        Icon = TouModifierIcons.Operative,
        IntroSound = TouAudio.SpyIntroSound
    };

    [HideFromIl2Cpp]
    public StringBuilder SetTabText()
    {
        return ITownOfUsRole.SetNewTabText(this);
    }

    public string GetAdvancedDescription()
    {
        return
            $"The Operative is a Crewmate Investigative role with the ability to use vitals and cameras or door logs (pending on map) remotely."
            + MiscUtils.AppendOptionsText(GetType());
    }

    [HideFromIl2Cpp]
    public List<CustomButtonWikiDescription> Abilities { get; } =
    [
        new("Vital",
            "Use Vitals for a short duration remotely.",
            TouAssets.VitalsSprite),
        new("Camera",
            $"Use Cameras for a short duration remotely.",
            TouAssets.CameraSprite)
    ];
}