using System;
using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour, IDamageAble
{
    //    [SerializeField] private float _speedMovement;
    //    [SerializeField] private float _damage;
    //    [SerializeField] private float _jumpForce;

    public int Health;
    public float JumpForce;
    public float SpeedMovement;
    public float Damage;

    // Новая переменная для монет
    public int CoinCount { get; private set; } = 0; // Инициализируем с 0

    // Метод для добавления монет
    public void AddCoins(int amount)
    {
        CoinCount += amount;
        Debug.Log("Монет: " + CoinCount); // Для проверки в консоли
    }
    //public void ChangeSpeedMovement(float speedIncreaseValue, float timeIncreasMovement)
    //{
    //    StartCoroutine (ChangeSpeedCoroutine(timeIncreasMovement, speedIncreaseValue));
    //}

    //internal void ChangeJumpForce(float increaseValue, float increaseTimer)
    //{
    //    StartCoroutine(ChangeJumpCoroutine(increaseTimer, increaseValue));
    //}

    //private IEnumerator ChangeJumpCoroutine(float timeIncreaseValue, float IncreaseValue)
    //{
    //    _jumpForce += IncreaseValue;
    //    yield return new WaitForSeconds(timeIncreaseValue);
    //    _jumpForce -= IncreaseValue;
    //}

    //private IEnumerator ChangeSpeedCoroutine(float timeIncreaseMovement, float speedIncreaseValue)
    //{
    //    _speedMovement += speedIncreaseValue;
    //    yield return new WaitForSeconds(timeIncreaseMovement);
    //    _speedMovement -= speedIncreaseValue;
    //}

    //public void ChangeDamage(float damageIncreaseValue, float timeIncreaseDamage)
    //{
    //    StartCoroutine(ChangeDamageCoroutine(timeIncreaseDamage, damageIncreaseValue));
    //}

    //private IEnumerator ChangeDamageCoroutine(float timeIncreaseValue, float increaseValue)
    //{
    //    _damage += increaseValue;
    //    yield return new WaitForSeconds(timeIncreaseValue);
    //    _damage -= increaseValue;
    //}

}
