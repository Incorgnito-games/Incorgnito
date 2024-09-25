using Godot;
using System;
using Incorgnito.scripts.General;


public partial class PlayerIdleState : Node
{


    public override void _Notification(int what)
    {
        base._Notification(what);

        if (what == 5001)
        {
            Player characterNode = GetOwner<Player>();
            characterNode.AnimationPlayerNode.Play(GameConstants.ANIM_IDLE_1);
        }
    }
}
