using System.Collections;
using UnityEngine;

public class AIEnemyFight : EnemyStats
{
    [SerializeField] private int _damageAmount = 10; // ���������� �����, ���������� ������

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ���� �� � ������� ��������� PlayerStats
        if (collision.TryGetComponent(out PlayerStats player))
        {
            // ������� ���� ������
            player.GetDamage(_damageAmount);
        }
    }
}
