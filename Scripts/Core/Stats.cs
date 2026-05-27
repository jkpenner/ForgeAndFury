using Godot;
using System;

[GlobalClass]
public partial class Stats : Resource
{
    [Export] public int STR { get; set; } = 10;
    [Export] public int AGI { get; set; } = 10;
    [Export] public int VIT { get; set; } = 10;
    [Export] public int INT { get; set; } = 10;
    [Export] public int LUK { get; set; } = 10;

    public int HP { get; set; }
    public int MP { get; set; }

    public void Initialize()
    {
        HP = VIT * 10;
        MP = INT * 5;
    }
}