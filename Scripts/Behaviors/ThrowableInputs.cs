using Godot;
using Godot.Collections;

public partial class ThrowableInputs : Node3D
{

	private RigidBody3D heldObject;

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("game_action"))
		{
			if (heldObject != null) return;

			var collision = CursorToWorld(OBJECTS);
			if (collision.Count > 0 && collision.ContainsKey("collider")) ;
			if (collision["collider"].AsGodotObject() is RigidBody3D rigidBody)
			{
				heldObject = rigidBody;
			}

			heldObject.Freeze = true;
		}

		if (@event.IsActionReleased("game_action"))
		{
			heldObject.Freeze = false;
			heldObject = null;
		}
	}


	private Vector3 _lastPosition;
	public override void _PhysicsProcess(double delta)
	{
		Vector3 worldPosition;
		var mouseRay = CursorToWorld(PLACE_PLANE);
		if (mouseRay.Count > 0)
			worldPosition = mouseRay["position"].AsVector3();
		else return;
		
		Vector3 displacement =  worldPosition - _lastPosition;
		_lastPosition = worldPosition;

		Vector3 velocity = displacement / (float)delta / 2;
		
		if (heldObject == null) return;
		
		heldObject.GlobalPosition = worldPosition;
		heldObject.LinearVelocity = velocity;
		
	}

	public const uint OBJECTS = 4;
	public const uint PLACE_PLANE = 2;
	public Dictionary CursorToWorld(uint PhysicMask = OBJECTS, int RayLength = 15)
	{
		PhysicsDirectSpaceState3D spaceState = GetWorld3D().DirectSpaceState;
		Camera3D playerCamera = GetViewport().GetCamera3D();
		Vector2 mousePosition = GetViewport().GetMousePosition();

		Vector3 start = playerCamera.ProjectRayOrigin(mousePosition);
		Vector3 end = playerCamera.ProjectPosition(mousePosition, RayLength);

		PhysicsRayQueryParameters3D query = PhysicsRayQueryParameters3D.Create(start, end, PhysicMask);

		return spaceState.IntersectRay(query);
	}
}
