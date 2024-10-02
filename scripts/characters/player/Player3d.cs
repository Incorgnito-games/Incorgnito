using Godot;

using Incorgnito.scripts.General;

namespace Incorgnito.scripts.characters.player;
public partial class Player3d : CharacterBody3D
{
	public const float Speed = 2f;
	public const float JumpVelocity = 4.5f;

	[Export] private AnimationPlayer AnimationPlayerNode { set; get; }
	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;


		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed(GameConstants.INPUT_MV_JUMP) && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		Vector2 inputDir = Input.GetVector(GameConstants.INPUT_MV_LEFT, GameConstants.INPUT_MV_RIGHT, GameConstants.INPUT_MV_FWRD, GameConstants.INPUT_MV_BCKWRD);
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
			
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		if (velocity.Length() > 0.1)
		{
			if (AnimationPlayerNode.CurrentAnimation != GameConstants.ANIM_WALK)
			{
				AnimationPlayerNode.Play(GameConstants.ANIM_WALK);
				
			}
		}
		else
		{
			AnimationPlayerNode.Play(GameConstants.ANIM_IDLE_1);
			
		}
		Velocity = velocity;
		MoveAndSlide();
	}
}
