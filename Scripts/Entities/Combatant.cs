using Godot;

public partial class Combatant : Node
{
    [Export] public Stats BaseStats { get; set; }
    public Stats CurrentStats { get; set; }

    public void TakeDamage(int amount)
    {
        CurrentStats.HP -= amount;
        GD.Print(Name + " took " + amount + " damage!");
    }
}