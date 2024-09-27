using Godot;
using System;
using Incorgnito.scripts.General;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required  Nodes")]
    [Export]public AnimationPlayer AnimationPlayerNode;
    [Export]public Sprite3D Sprite3DNode;
    [Export]public StateMachine StateMachineNode;

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
