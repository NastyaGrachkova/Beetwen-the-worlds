using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour, IDamageAble
{
    public int Health;

    [SerializeField] public Slider _slider;

    public float JumpForce;
    public float SpeedMovement;
    public float Damage;
    public int PlayerDamage;

    // ����� ���������� ��� �����
    public int CoinCount { get; private set; } = 0; 

    [SerializeField] private GameObject gameOverImage;

    // ������ �� ��������� ������� ��� ����������� �������� �����
    [SerializeField] private TMPro.TextMeshProUGUI coinText; 

    // ����� ��� ���������� �����
    public void AddCoins(int amount)
    {
        CoinCount += amount;
        UpdateCoinText(); // ��������� ����� ��� ���������� �����
        Debug.Log("Coins: " + CoinCount); // ��� �������� � �������
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + CoinCount; // ��������� �����
        }
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
        Debug.Log("��������: " + Health);
    }

    private void ShowGameOver()
    {
        // ���������� Game Over Image
        if (gameOverImage != null)
        {
            gameOverImage.SetActive(true);
        }
        Debug.Log("���� ��������!");
        // ��������� ����
        Time.timeScale = 0; 
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("Menu"); 
    }
}
