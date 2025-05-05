using UnityEngine;
using Zenject;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    [Inject]
    void Constract(AudioSource audioSource)
    {
        _audioSource = audioSource;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            _audioSource.PlayOneShot(_audioClip);
            if (playerStats != null)
            {
                playerStats.AddCoins(coinValue);
                Destroy(gameObject);
            }
        }
    }
}






