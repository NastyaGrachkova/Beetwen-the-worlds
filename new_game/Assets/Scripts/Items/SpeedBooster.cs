using System.Collections;
using UnityEngine;

public class SpeedBooster : Item
{
    public override IEnumerator PickUpItem(PlayerStats player)
    {
        player.SpeedMovement += IncreaseValue;
        AudioSorce.PlayOneShot(AudioClip);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(IncreaseDuration);
        player.SpeedMovement -= IncreaseValue;
        GameObject.Destroy(gameObject);
    }
}

