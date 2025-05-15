using UnityEngine;

public class IDLEState : BaseState<BossStates>
{
    public IDLEState(BossStates estate) : base(estate)
    {
    }

    public override void EnterToState()
    {
        Debug.Log("���� ����");
    }

    public override void ExitToState()
    {
        
    }
}
