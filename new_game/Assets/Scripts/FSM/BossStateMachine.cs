public class BossStateMachine : StateInspector<BossStates>
{
    public BossStateMachine(MonoBehaviourProcess monoBehaviourProcess)
    {
        FireBallCastingState fireBallCastingState = new FireBallCastingState(BossStates.FireBallCasting, monoBehaviourProcess);


        LightingCastingState lightingCastingState = new LightingCastingState(BossStates.LightingBallCasting);

        States.Add(BossStates.FireBallCasting, fireBallCastingState);
        States.Add(BossStates.LightingBallCasting, lightingCastingState);

        StartStateMachine(BossStates.FireBallCasting);
    }
}
