namespace Incorgnito.scripts.characters.player;

using Godot;
using General;

public partial class PlayerJumpState : PlayerState
{
    [Export]private Timer _jumpTimerNode;
    public override void _Ready()
    { 
        base._Ready(); 
        _jumpTimerNode.Timeout += HandleJumpTimeout;
    }
    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == GameConstants.NOTIFICATION_ENTER_STATE)
        {
            _jumpTimerNode.Start();
        }
    }

    private void HandleJumpTimeout()
    {
        CharacterNode.StateMachineNode.SwitchState<PlayerIdleState>();
    }

    protected override void _PlayAnimation()
    {
        GD.Print("Moving");
        CharacterNode.AnimationPlayerNode.Play(GameConstants.ANIM_JUMP);  
    }
}
