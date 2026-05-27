using Godot;
using System.Collections.Generic;

public partial class TurnManager : Node
{
    private List<Combatant> initiativeQueue = new();

    public void CalculateInitiative(List<Combatant> combatants)
    {
        // Simple speed based sort
        initiativeQueue = new List<Combatant>(combatants);
        initiativeQueue.Sort((a, b) => b.CurrentStats.AGI.CompareTo(a.CurrentStats.AGI));
    }
}