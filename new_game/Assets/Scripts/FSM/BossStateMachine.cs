using UnityEngine.InputSystem.XR.Haptics;

public class BossStateMachine : StateInspector<BossStates>
{
    public BossStateMachine(MonoBehaviourProcess monoBehaviourProcess, FireBallCastingState.Setting fireballSetting, LightingCastingState.Setting lightingSetting)
    {
        FireBallCastingState fireBallCastingState = new FireBallCastingState(BossStates.FireBallCasting, monoBehaviourProcess, fireballSetting);


        LightingCastingState lightingCastingState = new LightingCastingState(BossStates.LightingBallCasting, lightingSetting, monoBehaviourProcess);

        IDLEState idle = new IDLEState(BossStates.IDLE);

        States.Add(BossStates.FireBallCasting, fireBallCastingState);
        States.Add(BossStates.LightingBallCasting, lightingCastingState);
        States.Add(BossStates.IDLE, idle);

        StartStateMachine(BossStates.FireBallCasting);
    }

    public void DisableMachine()
    {
        StartStateMachine(BossStates.IDLE);
        //CurentState.
    }
}
