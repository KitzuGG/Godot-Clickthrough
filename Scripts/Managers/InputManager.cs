using Godot;

	// Autoloaded
public partial class InputManager : Node
{

	private PackedScene _mainScene = GD.Load<PackedScene>("uid://cqrmmb1qw1yve");
	
	[Signal]
	public delegate void DoSomethingEventHandler();

	public override void _Input(InputEvent @event)
	{
  		if (@event.IsActionPressed("ui_cancel"))
	   {
				GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("uid://cqrmmb1qw1yve"));
		}
	}
}
