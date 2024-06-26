// This code has been made by Simon VRANA.
// Please ask by email (simon.vrana.pro@gmail.com) before reusing for commercial purpose.

using Godot;
using System;

public partial class WidthSelector : SpinBox
{
	[Export]
	private GameController gameController;

	public override void _ValueChanged(double newValue)
	{
		base._ValueChanged(newValue);

		gameController.SetGridWidth((int)Math.Round(newValue));
	}
}