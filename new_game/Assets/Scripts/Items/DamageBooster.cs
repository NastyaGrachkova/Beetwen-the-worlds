using System.Collections;
using UnityEngine;

public class DamageBooster : Item
{
    public override IEnumerator PickUpItem(PlayerStats player)
    {
        player.Damage += IncreaseValue;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(IncreaseDuration);
        player.Damage -= IncreaseValue;
        GameObject.Destroy(gameObject);
    }
}

