using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.AddCoins(coinValue);
                Destroy(gameObject);
            }
        }
    }
}
