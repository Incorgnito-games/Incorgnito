using Godot;
using System;

public partial class TestLabel : Label3D
{
	[Export] public double MoveSpeed = 1000;
	[Export] public Vector3 Direction = Vector3.Left;
	private static readonly Vector3 StartingPoint = new() {X =0, Y = 0, Z = 0};
	
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		Position = Position with
		{
			X = (float)(Position.X + MoveSpeed * delta * Direction.X),
			Y = (float)(Position.Y + MoveSpeed * delta * Direction.Y),
			Z = (float)(Position.Z + MoveSpeed * delta * Direction.Z)
		};
		
	}
	
	public void Reset(Vector3 direction)
	{
		Direction = direction;
		Position = StartingPoint;
	}
	
	public void Bounce(Vector3 direction)
	{
		Direction = direction;
	}
}
