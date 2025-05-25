using System;
using UnityEngine;

public class BossItem : Coin
{
    internal void Inicialize(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }
}
