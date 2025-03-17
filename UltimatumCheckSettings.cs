//using System;
//using System.Collections.Generic;
//using System.Linq;
//using ExileCore.PoEMemory;
//using ExileCore.Shared.Attributes;
//using ImGuiNET;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;
using SharpDX;

namespace UltimatumCheck;

public class UltimatumCheckSettings : ISettings
{
    //Mandatory setting to allow enabling/disabling your plugin
    public ToggleNode Enable { get; set; } = new(false);

    //Put all your settings here if you can.
    //There's a bunch of ready-made setting nodes,
    //nested menu support and even custom callbacks are supported.
    //If you want to override DrawSettings instead, you better have a very good reason.
    public ColorNode PickColor { get; set; } = new(Color.Cyan);
    public RangeNode<int> FrameThickness { get; set; } = new(3, 0, 10);
    //public UltimatumModRanking UltimatumModRanking { get; set; } = new();
}

//[Submenu(RenderMethod = nameof(Render))]
//public class UltimatumModRanking
//{
//    public Dictionary<string, int> TierMapping = [];
//    private string _roomFilter = "";

//    public void Render()
//    {
//        ImGui.InputTextWithHint("##ModFilter", "Filter", ref _roomFilter, 100);
//        foreach (var mod in RemoteMemoryObject.pTheGame.Files.UltimatumModifiers.EntriesList
//                     .Where(t => t.Name.Contains(_roomFilter, StringComparison.OrdinalIgnoreCase) ||
//                                 t.Description.Contains(_roomFilter, StringComparison.OrdinalIgnoreCase)))
//        {
//            var currentValue = GetModifierTier(mod.Id);
//            if (ImGui.SliderInt($"{(string.IsNullOrWhiteSpace(mod.Name) ? mod.Id : mod.Name)}###{mod.Id}", ref currentValue, 1, 3))
//            {
//                TierMapping[mod.Id] = currentValue;
//            }

//            if (!string.IsNullOrWhiteSpace(mod.Description) && ImGui.BeginItemTooltip())
//            {
//                ImGui.TextUnformatted(mod.Description);
//                ImGui.EndTooltip();
//            }
//        }
//    }

//    public int GetModifierTier(string id)
//    {
//        return TierMapping.GetValueOrDefault(id, 2);
//    }
//}