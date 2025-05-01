using Pathfinding;
using System.Collections;
using UnityEngine;

public class AIEnemyFight : EnemyStats
{
    [SerializeField] private int _damageAmount = 10; // ���������� �����, ���������� ������
    [SerializeField] private float _moveSpeed = 2f; // �������� �������� �����

    private SpriteRenderer sprite;
    [SerializeField] private AIPath aiPath;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        sprite.flipX = aiPath.desiredVelocity.x >= 0.01f;
    }


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
