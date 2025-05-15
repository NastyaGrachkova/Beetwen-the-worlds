using UnityEngine;

public class IDLEState : BaseState<BossStates>
{
    public IDLEState(BossStates estate) : base(estate)
    {
    }

    public override void EnterToState()
    {
        Debug.Log("Босс умер");
    }

    public override void ExitToState()
    {
        
    }
}
