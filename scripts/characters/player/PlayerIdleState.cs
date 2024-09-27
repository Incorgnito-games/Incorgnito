namespace Incorgnito.scripts.characters.player;

using Godot;
using General;

public partial class PlayerIdleState : PlayerState
{
    
    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.Direction != Vector2.Zero)
        {
            CharacterNode.StateMachineNode.SwitchState<PlayerMoveState>();
        }
     
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
        GD.Print("idling");
        CharacterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE_1);
    }
}
