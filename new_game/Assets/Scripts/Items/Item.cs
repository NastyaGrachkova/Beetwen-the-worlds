using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float IncreaseValue;
    [SerializeField] protected float IncreaseTimer;
    protected PlayerStats PlayerStats;
    public abstract void PickUpItem();
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerStats player))
        {
            PlayerStats = player;
            PickUpItem();
        }
    }
}
