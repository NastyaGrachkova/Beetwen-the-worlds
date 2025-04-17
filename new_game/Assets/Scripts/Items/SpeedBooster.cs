using UnityEngine;

public class SpeedBooster : Item
{
    public override void PickUpItem()
    {
        Debug.Log("Increase speed");
    }
}

public class DamageBooster : Item
{
    public override void PickUpItem()
    {
        Debug.Log("Increase damage");
    }
}
