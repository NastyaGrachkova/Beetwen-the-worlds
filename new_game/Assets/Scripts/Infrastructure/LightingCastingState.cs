using UnityEngine;

public class LightingCastingState : BaseState<BossStates>
{
    public LightingCastingState(BossStates estate) : base(estate)
    {
    }

    public override void EnterToState()
    {
        Debug.Log("Молния");
    }

    public override void ExitToState()
    {
        Debug.Log("Выход из состояния молния");
    }
}
