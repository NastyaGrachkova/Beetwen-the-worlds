using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // ��� �����, �� ������� ����� �������
    public string nextSceneName = "Hub";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ��� ������, ������� ����� � �������, - ��� �����
        if (collision.CompareTag("Player"))
        {
            // ��������� ��������� �����
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
