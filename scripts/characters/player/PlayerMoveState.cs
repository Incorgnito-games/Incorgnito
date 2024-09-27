namespace Incorgnito.scripts.characters.player;

using Godot;
using General;

public partial class PlayerMoveState : PlayerState
{
    
   public override void _PhysicsProcess(double delta)
   {   
       if (CharacterNode.Direction == Vector2.Zero)
       {
           CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
           return;
       }
       
       CharacterNode.Velocity = new Vector3(CharacterNode.Direction.X,0,CharacterNode.Direction.Y);
       
       CharacterNode.MoveAndSlide(); 
       CharacterNode.Flip_Sprite();
   }
   
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_MV_JUMP))
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerJumpState>();
        }
    }

    protected override void _PlayAnimation()
    {
        GD.Print("Moving");
        CharacterNode.AnimationPlayerNode.Play(GameConstants.ANIM_WALK); 
    }
}
