using Godot;
using System;
using Incorgnito.scripts.General;

public partial class StateMachine : Node
{
    [Export]private Node _currentState;
    [Export]private Node[] _states;

    public override void _Ready()
    {
    
        _currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }

    public void SwitchState<T>()
    {
        Node newState = null;

        foreach (var state in _states)
        {
            if (state is T)
            {
                newState = state;
            }
        }

        if (newState == null)
        {
            return;
        }

        _currentState.Notification(GameConstants.NOTIFICATION_EXIT_STATE);
        _currentState = newState;
        _currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }
}
