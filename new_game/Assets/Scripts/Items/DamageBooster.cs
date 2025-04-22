using UnityEngine;

public class DamageBooster : Item
{
    public override void PickUpItem()
    {
        if (PlayerStats != null)
        {
            PlayerStats.ChangeDamage(IncreaseValue, IncreaseTimer);
            Destroy(gameObject);
        }
    }
}

