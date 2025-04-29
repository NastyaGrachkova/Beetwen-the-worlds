using System.Collections;
using UnityEngine;

public class AIEnemyFight : EnemyStats
{
    [SerializeField] private int _damageAmount = 10; // Количество урона, наносимого игроку

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, есть ли у объекта компонент PlayerStats
        if (collision.TryGetComponent(out PlayerStats player))
        {
            // Наносим урон игроку
            player.GetDamage(_damageAmount);
        }
    }
}
