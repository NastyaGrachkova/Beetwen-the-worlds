using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IDamageAble
{
    public int Health;

    [SerializeField] private Slider _slider;

    public float JumpForce;
    public float SpeedMovement;
    public float Damage;
    public int PlayerDamage;

    // Новая переменная для монет
    public int CoinCount { get; private set; } = 0; 

    [SerializeField] private GameObject gameOverImage;

    // Метод для добавления монет
    public void AddCoins(int amount)
    {
        CoinCount += amount;
        Debug.Log("Монет: " + CoinCount); // Для проверки в консоли
    }

    public void GetDamage(int damageValue)
    {
        if (Health - damageValue <= 0)
        {
            Health = 0;
            ShowGameOver();
        }
        else
        {
            Health -= damageValue;
        }
        _slider.value = Health;
        Debug.Log("Здоровье: " + Health);
    }

    private void ShowGameOver()
    {
        // Отображаем Game Over Image
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true);
        }
        Debug.Log("Игра окончена!");
        // Остановка игры
        Time.timeScale = 0; 
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Menu"); 
    }
}
