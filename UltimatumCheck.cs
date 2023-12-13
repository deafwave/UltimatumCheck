using System.Linq;
using System.Runtime.CompilerServices;
using ExileCore;
using ExileCore.PoEMemory;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.Elements;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Cache;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Helpers;
using SharpDX;

namespace UltimatumCheck;

public class UltimatumCheck : BaseSettingsPlugin<UltimatumCheckSettings>
{
    private readonly ConditionalWeakTable<Entity, CachedValue<Element>> _entityMapping = new();

    public override bool Initialise()
    {
        return true;
    }

    public override Job Tick()
    {
        return null;
    }

    public override void Render()
    {
        if (GameController.EntityListWrapper.ValidEntitiesByType[EntityType.IngameIcon]
                    .FirstOrDefault(x => x.Path == "Metadata/Terrain/Leagues/Ultimatum/Objects/UltimatumChallengeInteractable") is
                { } encounterEntity && encounterEntity.TryGetComponent<StateMachine>(out var stateMachine) &&
            stateMachine.States.FirstOrDefault(x => x.Name == "encounter_started")?.Value is 0 or null)
        {
            var element = _entityMapping.GetValue(encounterEntity,
                    ee => new TimeCache<Element>(() => GameController.IngameState.IngameUi.ItemsOnGroundLabelsVisible.FirstOrDefault(x => Equals(x.ItemOnGround, ee))?.Label,
                        1000))!
                .Value;
            var choicesPanel = element?.GetChildFromIndices(0, 0, 2)?.AsObject<UltimatumChoicePanel>();
            if (choicesPanel is { IsVisible: true })
            {
                DrawModifierOptions(choicesPanel);
            }
        }

        if (GameController.IngameState.IngameUi.UltimatumPanel is { IsVisible: true, ChoicesPanel: { } panel })
        {
            DrawModifierOptions(panel);
        }
    }

    private void DrawModifierOptions(UltimatumChoicePanel panel)
    {
        foreach (var ((element, modifier), index) in panel.ChoiceElements.Zip(panel.Modifiers).Select((x, i) => (x, i)))
        {
            Color modColor = Settings.UltimatumModRanking.GetModifierTier(modifier.Id) switch
            {
                1 => Settings.Rank1Color,
                2 => Settings.Rank2Color,
                3 => Settings.Rank3Color,
                _ => Color.Gray
            };
            Graphics.DrawFrame(
                element.GetClientRectCache.TopLeft.ToVector2Num(),
                element.GetClientRectCache.BottomRight.ToVector2Num(),
                modColor, Settings.FrameThickness + (panel.SelectedChoice == index ? 5 : 0));
        }
    }
}