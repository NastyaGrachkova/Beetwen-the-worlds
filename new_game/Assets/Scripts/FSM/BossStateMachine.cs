public class BossStateMachine : StateInspector<BossStates>
{
    public BossStateMachine(MonoBehaviourProcess monoBehaviourProcess, FireBallCastingState.Setting fireballSetting, LightingCastingState.Setting lightingSetting)
    {
        FireBallCastingState fireBallCastingState = new FireBallCastingState(BossStates.FireBallCasting, monoBehaviourProcess, fireballSetting);


        LightingCastingState lightingCastingState = new LightingCastingState(BossStates.LightingBallCasting, lightingSetting, monoBehaviourProcess);

        States.Add(BossStates.FireBallCasting, fireBallCastingState);
        States.Add(BossStates.LightingBallCasting, lightingCastingState);

        StartStateMachine(BossStates.FireBallCasting);
    }
}
