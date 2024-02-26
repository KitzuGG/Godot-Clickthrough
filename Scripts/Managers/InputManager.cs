using Godot;

public partial class InputManager : Node
{
	// Autoloaded
	
	[Signal]
	public delegate void DoSomethingEventHandler();

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("game_action"))
		{
			EmitSignal("DoSomething");
		}
  		if (@event.IsActionPressed("ui_cancel"))
		{
			GetTree().Quit();
		}
	}
}
