using Godot;
using System;
using Incorgnito.scripts.General;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required  Nodes")]
    [Export]
    private AnimationPlayer _animationPlayerNode;
    [Export]
    private Sprite3D _sprite3DNode;
    
    private Vector2 _direction;

    public override void _Ready()
    {
    }
    
    
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(_direction.X,0,_direction.Y);
        

        MoveAndSlide();
        Flip_Sprite();
    }

    public override void _Input(InputEvent @event)
    {
        _direction = Input.GetVector(
            GameConstants.INPUT_MV_LEFT,
            GameConstants.INPUT_MV_RIGHT,
            GameConstants.INPUT_MV_FWRD,
            GameConstants.INPUT_MV_BCKWRD);
        if(_direction == Vector2.Zero)
        {
            _animationPlayerNode.Play(GameConstants.ANIM_IDLE_1);
        }
        else
        {
            _animationPlayerNode.Play(GameConstants.ANIM_WALK);
        }

    }

    private void Flip_Sprite()
    {
        bool isNotMovingHorizontally = Velocity.X == 0;

        if (isNotMovingHorizontally)
        {
            return;
            
        }
        
        bool isMovingLeft = Velocity.X < 0;
        _sprite3DNode.FlipH = isMovingLeft;
    }
}
