using System.Collections;
using UnityEngine;

public class FireBallCastingState : BaseState<BossStates>
{
    private MonoBehaviourProcess _mono;

    public FireBallCastingState(BossStates estate, MonoBehaviourProcess monoBehaviourProcess) : base(estate)
    {
        _mono = monoBehaviourProcess;
    }

    public override void EnterToState()
    {
        Debug.Log("Огненные шары");
        IBossSpell spell = GameObject.Instantiate<FireBall>(Resources.Load<FireBall>("Prefabs/FireBall"));
    }

    public override void ExitToState()
    {
        Debug.Log("Выход из состояния огненные шары");
    }

    private IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ChangeState(BossStates.LightingBallCasting);
    }
}
