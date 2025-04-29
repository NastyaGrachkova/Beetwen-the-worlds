using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // ��� �����, �� ������� ����� �������
    public string nextSceneName = "Hub";
    private const int totalCoins = 3; // ����� ���������� �����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ��� ������, ������� ����� � �������, - ��� �����
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                if (playerStats.CoinCount >= totalCoins)
                {
                    // ��������� ��������� �����, ���� ������� ��� ������
                    SceneManager.LoadScene(nextSceneName);
                }
                else
                {
                    //Debug.Log("�������� ��� ������, ����� ������� ������!"); // ��������� ��� ������
                }
            }
        }
    }
}
