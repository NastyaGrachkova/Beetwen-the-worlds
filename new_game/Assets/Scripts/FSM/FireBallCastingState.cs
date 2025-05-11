using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Unity.VisualScripting;

public class FireBallCastingState : BaseState<BossStates>
{
    private Setting _fireballSetting;
    private MonoBehaviourProcess _mono;
    private WaitForSeconds _sleep;
    [Serializable] 
    public class Setting
    {
        public float IntervalCasting;
        public int MaxAmountOfFireBall;
        public List<Transform> CastingPositions;
        public PlayerStats Stats;
        public int AmountCast;
    }

    public FireBallCastingState(BossStates estate, MonoBehaviourProcess monoBehaviourProcess, Setting fireballSetting) : base(estate)
    {
        _fireballSetting = fireballSetting;
        _mono = monoBehaviourProcess;
    }

    public override void EnterToState()
    {
        _sleep = new WaitForSeconds(_fireballSetting.IntervalCasting);
        Debug.Log("�������� ����");
        _mono.StartCoroutine(StartCastingSpell());
        _mono.StartCoroutine(Wait(5));

    }

    private IEnumerator StartCastingSpell()
    {
        for (int i = 0; i < Random.Range(3, _fireballSetting.MaxAmountOfFireBall); i++)
        {
            FireBall spell = GameObject.Instantiate<FireBall>(Resources.Load<FireBall>("Prefabs/FireBall"));
            Transform positionToStart = _fireballSetting.CastingPositions[Random.Range(0, _fireballSetting.CastingPositions.Count)];
            spell.transform.position = positionToStart.position;
            spell.InicializeFireBall(_fireballSetting.Stats.transform.position);
            yield return _sleep;
        }
    }

    public override void ExitToState()
    {
        Debug.Log("����� �� ��������� �������� ����");
    }

    private IEnumerator Wait(int seconds)
    {
        int castAmount = _fireballSetting.AmountCast;
        while (castAmount > 0)
        {
            yield return new WaitForSeconds(seconds);
            _mono.StartCoroutine(StartCastingSpell());
            castAmount--;
        }
        ChangeState(BossStates.LightingBallCasting);
    }
}
