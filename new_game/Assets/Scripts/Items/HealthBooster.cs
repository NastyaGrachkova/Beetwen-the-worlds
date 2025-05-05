using System.Collections;
using UnityEngine;

public class HealthBooster : Item
{
    public override IEnumerator PickUpItem(PlayerStats player)
    {
        player.Health += (int)IncreaseValue;
        AudioSorce.PlayOneShot(AudioClip);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        player._slider.value = player.Health;

        GameObject.Destroy(gameObject);

        yield return null; 
    }
}

