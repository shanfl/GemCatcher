using Godot;
using System;

public partial class Game : Node2D
{


	private AudioStream _explodeStream = GD.Load<AudioStream>("res://assets/explode.wav");
	[Export] private Gem _gem;
	[Export] private NodePath _gemPath;

	[Export] private PackedScene _gemScene;

	[Export] private AudioStreamPlayer2D _effectPlayer;

	//[Export] private AudioStream _explodeStream;

	private int _score = 0;

	//Gem gem = _gemScene.Instantiate<Gem>();
	//

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Game Scene Loaded");

		// method 1: using exported NodePath
		//Gem gem = GetNode<Gem>("Gem");
		//gem.OnScored += OnGemScored;
		
		//method 2: using exported Gem variable		
		//_gem.OnScored += OnGemScored;

		//method 3: using GetNode with the NodePath
		// nodepath 不用指定类型,更灵活一些
		Gem gem = GetNode<Gem>(_gemPath);
		gem.OnScored += OnGemScored;

		//
		
		Timer timer = GetNode<Timer>("Timer");
		timer.Timeout+= SpawnGem;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GD.Print("Frame updated with delta time: " + delta);


	}

	private void SpawnGem()
	{
		Gem gem = _gemScene.Instantiate<Gem>();
		AddChild(gem);
		gem.Position = new Vector2(GD.RandRange(10, 800), 0);

		gem.OnScored += OnGemScored;
		gem.OnMissed += OnGemMissed;
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


	public void OnGemScored()
	{
		GD.Print("Gem scored signal received in Game");
		//SpawnGem();
		_score +=1;

		GetNode<Label>("Label").Text = "" + _score;

		_effectPlayer.Play();
	}	
	

	public void OnGemMissed()
	{
		GD.Print("Gem missed signal received in Game");
		//SpawnGem();
		foreach(Node node in GetChildren())
		{
			node.SetProcess(false);
		}

		GetNode<Timer>("Timer").Stop();
		GetNode<AudioStreamPlayer>("Music").Stop();

		_effectPlayer.Stream = _explodeStream;
		_effectPlayer.Play();
	}
}
