using UnityEngine;

public class JumpBooster : Item
{
    public override void PickUpItem()
    {
        if (PlayerStats != null)
        {
            PlayerStats.ChangeJumpForce(IncreaseValue, IncreaseTimer);
            Destroy(gameObject);
        }
        
    }
}
