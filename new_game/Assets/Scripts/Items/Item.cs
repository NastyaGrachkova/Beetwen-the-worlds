using System.Collections;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float IncreaseValue;
    [SerializeField] protected float IncreaseDuration;
    public abstract IEnumerator PickUpItem(PlayerStats player);
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerStats player))
        {
            StartCoroutine(PickUpItem(player));
        }
    }
}
