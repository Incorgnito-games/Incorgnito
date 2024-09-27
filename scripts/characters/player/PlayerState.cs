namespace Incorgnito.scripts.characters.player;
using Godot;
using General;
public abstract partial class PlayerState: Node
{
    
    protected Player CharacterNode;
    public override void _Ready()
    { 
        CharacterNode= GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }
    public override void _Notification(int what)
       {
           base._Notification(what);

           switch (what)
           { 
               case GameConstants.NOTIFICATION_ENTER_STATE: 
                   _PlayAnimation();
                   SetPhysicsProcess(true);
                   SetProcessInput(true);
                   break;
               case GameConstants.NOTIFICATION_EXIT_STATE:
                   SetPhysicsProcess(false); 
                   SetProcessInput(false); 
                   break;
           }
       }

    protected virtual void _PlayAnimation() { }
}