// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;

public partial class GameController : Node
{
	[Export]
	private Color aliveColor;

	[Export]
	private Color deadColor;

	private GameModel model;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		model = new GameModel
		{
			aliveColor = aliveColor,
			deadColor = deadColor,

			gridWidth = 16,

			isPlaying = false,

			numberOfFramesBetweenUpdates = 1
		};

		MakeTexture();
	}

	private void MakeTexture()
	{
		model.texture = new Texture2D();
		model.texture.
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}