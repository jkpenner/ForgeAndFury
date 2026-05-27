// Full Battle UI Controller
using Godot;
using System.Collections.Generic;

public partial class BattleUI : CanvasLayer
{
    [Export] public Control ActionMenu;
    [Export] public Control TargetSelectionPanel;
    [Export] public Label TurnQueueLabel;

    private Combatant currentCombatant;
    private List<Combatant> targets = new();

    public void ShowActionMenu(Combatant combatant)
    {
        currentCombatant = combatant;
        ActionMenu.Visible = true;
        // Populate skills, attack, etc.
    }

    public void OnSkillSelected(int skillIndex)
    {
        ActionMenu.Visible = false;
        ShowTargetSelection(skillIndex);
    }

    private void ShowTargetSelection(int skillIndex)
    {
        TargetSelectionPanel.Visible = true;
        // Populate possible targets based on skill
    }

    public void OnTargetSelected(Combatant target)
    {
        TargetSelectionPanel.Visible = false;
        if (currentCombatant is PlayerCharacter pc)
        {
            pc.PerformSkill(skillIndex, target); // example
        }
        TurnManager.Instance.EndCurrentTurn();
    }

    public void UpdateTurnQueue(List<Combatant> queue)
    {
        TurnQueueLabel.Text = "Turn Order: " + string.Join(" -> ", queue.Select(c => c.Name));
    }
}