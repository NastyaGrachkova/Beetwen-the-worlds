using UnityEngine;

public class SpeedBooster : Item
{
    
    public override void PickUpItem()
    {
        if (PlayerStats != null)
        {
            PlayerStats.ChangeSpeedMovement(IncreaseValue, IncreaseTimer);
            GameObject.Destroy(gameObject);
        }
    }
    
}

