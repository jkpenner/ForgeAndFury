// Enhanced TurnManager with full combat loop
using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class TurnManager : Node
{
    public signal TurnStarted(Combatant current);
    public signal TurnEnded(Combatant previous);
    public signal CombatEnded(string result);

    private List<Combatant> initiativeQueue = new();
    private int currentIndex = 0;

    public void InitializeCombat(List<Combatant> players, List<Combatant> enemies)
    {
        initiativeQueue.Clear();
        initiativeQueue.AddRange(players);
        initiativeQueue.AddRange(enemies);
        SortBySpeed();
        currentIndex = 0;
        StartNextTurn();
    }

    private void SortBySpeed()
    {
        initiativeQueue = initiativeQueue.OrderByDescending(c => c.Stats.AGI).ToList();
    }

    public void StartNextTurn()
    {
        if (CheckCombatEnd()) return;
        var current = initiativeQueue[currentIndex];
        EmitSignal(nameof(TurnStarted), current);
    }

    public void EndCurrentTurn()
    {
        var previous = initiativeQueue[currentIndex];
        EmitSignal(nameof(TurnEnded), previous);
        currentIndex = (currentIndex + 1) % initiativeQueue.Count;
        StartNextTurn();
    }

    private bool CheckCombatEnd()
    {
        bool playersAlive = initiativeQueue.Any(c => c is PlayerCharacter && !c.IsDead);
        bool enemiesAlive = initiativeQueue.Any(c => c is Enemy && !c.IsDead);
        if (!playersAlive || !enemiesAlive)
        {
            string result = playersAlive ? "Victory" : "Defeat";
            EmitSignal(nameof(CombatEnded), result);
            return true;
        }
        return false;
    }
}