using Godot;
using System;

public partial class Game : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
    {
        GD.Print("Game Scene Loaded");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        //GD.Print("Frame updated with delta time: " + delta);
    }

    public override void _EnterTree()
    {
        GD.Print("Game Scene Entered Tree");
		base._EnterTree();
    }

	public override void _ExitTree()
	{
		GD.Print("Game Scene Exit Tree");
		base._ExitTree();
	}

	public override void _PhysicsProcess(double delta)
	{
		//GD.Print("Physics Frame updated with delta time: " + delta);
	}
}
