using UnityEngine;

public class EnemyStats : MonoBehaviour, IDamageAble
{
    public int Health;

    public void GetDamage(int damageValue)
    {
        if (Health - damageValue < 0)
        {
            Health = 0;
            Destroy(gameObject);
        }
        else
        {
            Health = Health - damageValue;
        }
        Debug.Log("��������: " + Health);
    }
}
