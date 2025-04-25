using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Имя сцены, на которую нужно перейти
    public string nextSceneName = "Hub";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, что объект, который вошел в триггер, - это игрок
        if (collision.CompareTag("Player"))
        {
            // Загружаем следующую сцену
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
