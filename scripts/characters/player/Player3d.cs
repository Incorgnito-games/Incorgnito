using System;
using Godot;

using Incorgnito.scripts.General;

namespace Incorgnito.scripts.characters.player;
public partial class Player3d : CharacterBody3D
{
	public const double Gravity = -9.8;
	public const double Speed = 50;
	public const double JumpVelocity = 4.5;
	public const double Acceleration = 3;
	public const double DeAcceleration = 5;
	public Transform3D camera;
	public AnimationPlayer animationPlayerNode;
	public CharacterBody3D characterBody3DNode;
	
	// [Export] private AnimationPlayer AnimationPlayerNode { set; get; }
	public override void _Ready()
	{
		animationPlayerNode = GetNode<AnimationPlayer>("corgi_proto/AnimationPlayer");
		camera = GetNode<Camera3D>("%Camera3D").GetGlobalTransform();
		characterBody3DNode = GetNode<CharacterBody3D>("%Player_3d");
	}

	public override void _PhysicsProcess(double delta)
	{ 
		var dir = new Vector3();
		var velocity = new Vector3();
		var isMoving = false;

		if (Input.IsActionPressed(GameConstants.INPUT_MV_FWRD))
		{
			dir += -camera.Basis[2];
			isMoving = true;
		}
		if (Input.IsActionPressed(GameConstants.INPUT_MV_BCKWRD))
		{
			dir += camera.Basis[2];
			isMoving = true;
		}
		if (Input.IsActionPressed(GameConstants.INPUT_MV_LEFT))
		{
			dir += -camera.Basis[0];
			isMoving = true;
		}
		if (Input.IsActionPressed(GameConstants.INPUT_MV_RIGHT))
		{
			dir += camera.Basis[0];
			isMoving = true;
		}

		dir.Y = 0;
		dir = dir.Normalized();

		velocity.Y += (float)(delta * Gravity);

		var horizontalVelocity = velocity;
		horizontalVelocity.Y = 0;

		var newPos = dir * (float)Speed;
		var accel = DeAcceleration;
		
		if (dir.Dot(horizontalVelocity) > 0)
		{
			accel = Acceleration;
		}

		horizontalVelocity = horizontalVelocity.Lerp(newPos, (float)(accel * delta));

		velocity.X = horizontalVelocity.X;
		velocity.Z = horizontalVelocity.Z;

		if (isMoving)
		{
			var targetDirection = -dir;
			characterBody3DNode.LookAt(GlobalPosition + targetDirection, Vector3.Up);
			
		}
		
		if (velocity.Length() > 0.2)
		{
			if (animationPlayerNode.CurrentAnimation != GameConstants.ANIM_WALK)
			{
				animationPlayerNode.Play(GameConstants.ANIM_WALK);
				
			}
		}
		else
		{
			animationPlayerNode.Play(GameConstants.ANIM_IDLE_1);
			
		}
		
		GD.Print(velocity);
		Velocity = velocity;
		
		MoveAndSlide();

	}
}
