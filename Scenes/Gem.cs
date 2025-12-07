using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Gem : Area2D
{
	[Export] int SPEED = 200;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        Position += new Vector2(0, SPEED * (float)delta);
		CheckHitBottom();
    }


	private void CheckHitBottom()
    {
        if(Position.Y > GetViewportRect().End.Y)
		{
			//GD.Print("Gem hit the bottom");
		}
    }


	private void OnAreaEntered(Area2D area)
	{
		
	}
}
