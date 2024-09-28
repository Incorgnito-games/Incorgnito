namespace Incorgnito.scripts.characters.player;
using Godot;
using System;
using Incorgnito.scripts.General;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required  Nodes")]
    [Export]public AnimationPlayer AnimationPlayerNode { private set; get; }
    [Export]private Sprite3D Sprite3DNode {set; get; }
    [Export]public StateMachine StateMachineNode { private set; get; }

    public Vector2 Direction;
    
    public override void _PhysicsProcess(double delta)
    {
  
    }

    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(
            GameConstants.INPUT_MV_LEFT,
            GameConstants.INPUT_MV_RIGHT,
            GameConstants.INPUT_MV_FWRD,
            GameConstants.INPUT_MV_BCKWRD);
    }

    public void Flip_Sprite()
    {
        var isNotMovingHorizontally = (Velocity.X == 0);

        if (isNotMovingHorizontally)
        {
            return;
        }
        
        var isMovingLeft = (Velocity.X < 0);
        Sprite3DNode.FlipH = isMovingLeft;
    }
}
