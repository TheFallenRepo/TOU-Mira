using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;
using AmongUs.GameOptions;
using TownOfUs.Roles;
using TownOfUs.Modifiers;
using MiraAPI.Roles;

namespace TownOfUs.Patches.Debug
{
    [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.Update))]
    public static class RoleDebugDisplay
    {
        private static bool showRoles = false;
        private static GUIStyle guiStyle;
        
        public static void Postfix(PlayerControl __instance)
        {
            // Only handle input for the local player
            if (!__instance.AmOwner) return;
            
            // Toggle display with T key
            if (Input.GetKeyDown(KeyCode.T))
            {
                showRoles = !showRoles;
            }
            
            // Initialize GUI style if needed
            if (guiStyle == null)
            {
                guiStyle = new GUIStyle
                {
                    fontSize = 12,
                    normal = { textColor = Color.white }
                };
                guiStyle.padding = new RectOffset(5, 5, 5, 5);
            }
        }
        
        // This method will be called by OnGUI
        public static void OnGUI()
        {
            if (!showRoles) return;
            
            // Get all players
            var allPlayers = PlayerControl.AllPlayerControls.ToArray();
            if (allPlayers.Length == 0) return;
            
            // Create content for the debug window
            string debugText = "=== ROLE DEBUG INFO ===\n\n";
            
            foreach (var player in allPlayers)
            {
                if (player == null) continue;
                
                // Get player info
                string playerName = player.Data.PlayerName;
                bool isDead = player.Data.IsDead;
                bool isDisconnected = player.Data.Disconnected;
                
                // Get role information
                string roleName = "Unknown";
                string roleTeam = "Unknown";
                
                // Try to get role from Town of Us system
                var role = Role.GetRole(player);
                if (role != null)
                {
                    roleName = role.Name;
                    roleTeam = role.FactionName;
                }
                // Fallback to MiraAPI role system
                else if (RoleManager.Instance != null)
                {
                    var miraRole = RoleManager.Instance.GetRole(player.Data.Role.Role);
                    if (miraRole != null)
                    {
                        roleName = miraRole.NiceName;
                        roleTeam = miraRole.TeamType.ToString();
                    }
                }
                
                // Get modifiers
                string modifiersText = "";
                var modifiers = Modifier.GetModifiers(player);
                if (modifiers != null && modifiers.Count > 0)
                {
                    modifiersText = string.Join(", ", modifiers.Select(m => m.Name));
                }
                
                // Format player info
                string status = isDisconnected ? "DISCONNECTED" : (isDead ? "DEAD" : "ALIVE");
                string color = isDisconnected ? "#888888" : (isDead ? "#FF8888" : "#88FF88");
                
                debugText += $"<color={color}>{playerName} [{status}]</color>\n";
                debugText += $"Role: {roleName} ({roleTeam})\n";
                
                if (!string.IsNullOrEmpty(modifiersText))
                {
                    debugText += $"Modifiers: {modifiersText}\n";
                }
                
                debugText += "\n";
            }
            
            // Display the debug window
            GUI.Box(new Rect(10, 10, 400, 500), "");
            GUI.Label(new Rect(20, 20, 380, 480), debugText, guiStyle);
        }
    }

    // Patch to hook into the GUI rendering
    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HudManagerUpdatePatch
    {
        public static void Postfix()
        {
            RoleDebugDisplay.OnGUI();
        }
    }

    // Optional: Add a console message when the debug tool is toggled
    [HarmonyPatch(typeof(ChatController), nameof(ChatController.AddChat))]
    public static class ChatControllerAddChatPatch
    {
        private static bool lastShowState = false;
        
        public static void Prefix(ChatController __instance, PlayerControl sourcePlayer, string chatText)
        {
            if (RoleDebugDisplay.showRoles != lastShowState)
            {
                lastShowState = RoleDebugDisplay.showRoles;
                string message = RoleDebugDisplay.showRoles ? 
                    "Role debug display ENABLED" : "Role debug display DISABLED";
                
                if (AmongUsClient.Instance.AmClient)
                {
                    __instance.AddChat(PlayerControl.LocalPlayer, $"<color=#FFCC00>{message}</color>");
                }
            }
        }
    }
}