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
        Debug.Log("�������� ����");
        _mono.StartCoroutine(Wait(2));
    }

    public override void ExitToState()
    {
        Debug.Log("����� �� ��������� �������� ����");
    }

    private IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ChangeState(BossStates.LightingBallCasting);
    }
}
