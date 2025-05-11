using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingCastingState : BaseState<BossStates>
{
    private Setting _setting;
    private MonoBehaviourProcess _mono;

    [Serializable]
    public class Setting
    {
        public float IntervalCasting;
        public int MaxAmountOfLighting;
        public List<Transform> CastingPositions, StrikePosition;
        public int AmountCast;
    }
    public LightingCastingState(BossStates estate, Setting setting, MonoBehaviourProcess mono) : base(estate)
    {
        _setting = setting;
        _mono = mono;
    }

    private IEnumerator CastingSpell()
    {
        yield return null;
        for (int i = 0; i < _setting.CastingPositions.Count; i++)
        {
            //создаём префаб молнии 
            //создаём префаб места удара молнии 
            //после некоторой задержки бьём молнией в точку удара, создаём сферу для определения находится ли игрок в этом месте и наносим урон
        }
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
