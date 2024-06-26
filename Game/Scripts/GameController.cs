// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;
using System;

public partial class GameController : Node
{
	[Export]
	private Color aliveColor;

	[Export]
	private Color deadColor;

	[Export]
	private TextureRect gameTexture;

	private GameModel model;

	private readonly Random random = new();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		model = new GameModel
		{
			aliveColor = aliveColor,
			deadColor = deadColor,

			gridWidth = 496,

			isPlaying = false,

			numberOfFramesBetweenUpdates = 1
		};

		MakeTexture();
	}

	private void MakeTexture()
	{
		Image image = Image.Create(model.gridWidth, model.GridHeight, false, Image.Format.Rgb8);

		for (int widthIndex = 0; widthIndex < image.GetWidth(); widthIndex++)
		{
			for (int heightIndex = 0; heightIndex < image.GetHeight(); heightIndex++)
			{
				image.SetPixel(widthIndex, heightIndex, deadColor);
			}
		}

		gameTexture.Texture = ImageTexture.CreateFromImage(image);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void applyGameMecanicShager()
	{
	}

	public void RandomizeGrid()
	{
		Image image = Image.Create(model.gridWidth, model.GridHeight, false, Image.Format.Rgb8);

		for (int widthIndex = 0; widthIndex < image.GetWidth(); widthIndex++)
		{
			for (int heightIndex = 0; heightIndex < image.GetHeight(); heightIndex++)
			{
				try
				{
					int next = random.Next();
					int midValur = (int.MaxValue / 2);
					bool result = next > midValur;
					image.SetPixel(widthIndex, heightIndex, result ? deadColor : aliveColor);
				}
				catch { }
			}
		}

		gameTexture.Texture = ImageTexture.CreateFromImage(image);
	}

	public void ClearGrid()
	{
		Image image = Image.Create(model.gridWidth, model.GridHeight, false, Image.Format.Rgb8);

		for (int widthIndex = 0; widthIndex < image.GetWidth(); widthIndex++)
		{
			for (int heightIndex = 0; heightIndex < image.GetHeight(); heightIndex++)
			{
				try
				{
					image.SetPixel(widthIndex, heightIndex, deadColor);
				}
				catch { }
			}
		}

		gameTexture.Texture = ImageTexture.CreateFromImage(image);
	}

	public void SetGridWidth(int newWidth)
	{
		model.gridWidth = newWidth;
		MakeTexture();
	}
}