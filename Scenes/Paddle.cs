using Godot;
using System;

public partial class Paddle : Area2D
{

	[Export]
	private int Speed = 300;

	[Export] int Margin = 10;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        if(Input.IsActionPressed("right"))
		{
			Position += new Vector2(Speed * (float)delta, 0);
		}
        if (Input.IsActionPressed("left"))
        {
            Position -= new Vector2(Speed * (float)delta, 0);
        }

		Rect2 vpr = GetViewportRect();

		if(Position.X < vpr.Position.X + Margin)
        {
			GD.Print($"Clamping Left {vpr.Position.X}" );
            Position = new Vector2(vpr.Position.X + Margin, Position.Y);
        }
		if(Position.X > vpr.End.X - Margin)
        {
			GD.Print($"Clamping Right {vpr.End.X}" );
			Position = new Vector2(vpr.End.X - Margin, Position.Y);
        }

    }
}
