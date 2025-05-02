using Godot;

public partial class SpinningObject : MeshInstance3D
{
	// Just to show the window will adapt to the objects in the scene
	public override void _Process(double delta)
	{
		RotateY(5f * (float)delta);
	}
	
	// This will be called every time there is a mouse event in the window
	// just to notice: even if this should trigger every time the left mouse button is clicked,
	// the action only triggers when the window is clickable, so only when the mesh is clicked
	// (even without a real Collider)
	private void DoSomething()
	{
		// Simply move the mesh in a random position
		RandomNumberGenerator rng = new RandomNumberGenerator();
		int x = rng.RandiRange(-1,1);
		int y = rng.RandiRange(-1,1);
		int z = rng.RandiRange(-1,1);
		Position = new Vector3(x * 2f, y * 2f, z * 2f);
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("game_action"))
		{
			DoSomething();
		}

	}

	
}
