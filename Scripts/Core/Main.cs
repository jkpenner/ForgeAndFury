using Godot;

public partial class Main : Node2D
{
    public override void _Ready()
    {
        GD.Print("Main scene ready - Forge & Fury");
        // Load Hub by default
        GetTree().ChangeSceneToFile("res://Scenes/Hub.tscn");
    }
}
