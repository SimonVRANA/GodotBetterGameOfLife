// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;

public struct GameModel
{
	public uint gridWidth;
	public readonly uint GridHeight => gridWidth * 9 / 16;

	public bool isPlaying;

	public uint numberOfFramesBetweenUpdates;

	public Color aliveColor;
	public Color deadColor;

	public Texture texture;
}