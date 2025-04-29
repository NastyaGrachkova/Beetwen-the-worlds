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

    // ����� ���������� ��� �����
    public int CoinCount { get; private set; } = 0; 

    [SerializeField] private GameObject gameOverImage;

    // ����� ��� ���������� �����
    public void AddCoins(int amount)
    {
        CoinCount += amount;
        Debug.Log("�����: " + CoinCount); // ��� �������� � �������
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
