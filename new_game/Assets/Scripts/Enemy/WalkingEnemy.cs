//using UnityEngine;

//public class WalkingEnemy : EnemyStats
//{
//    [SerializeField] private int _damageAmount = 10; 
//    private float speed = 3.5f;
//    private Vector2 _dir;
//    private SpriteRenderer _sprite;

//    private void Start()
//    {
//        _dir = transform.right;
//    }

//    private void Update()
//    {
//        Move();
//    }

//    private void Move()
//    {
//        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * _dir.x, Time.deltaTime);

//        if (colliders.Length > 0) _dir *= -1f;
//        transform.position = Vector3.MoveTowards(transform.position, (Vector3)transform.position + new Vector3(_dir.x, _dir.y, 0), Time.deltaTime);
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        Debug.Log("������ ����� � �������: " + collision.name);
//        // ���������, ���� �� � ������� ��������� PlayerStats
//        if (collision.TryGetComponent(out PlayerStats player))
//        {
//            // ������� ���� ������
//            player.GetDamage(_damageAmount);
//        }
//    }
//}

using System.Collections;
using UnityEngine;

public class WalkingEnemy : EnemyStats
{
    public float patrolSpeed = 2f; // �������� ��������������

    [SerializeField] private int _damageAmount = 10; // ���������� �����, ���������� ������
    public float attackCooldown = 1f; // ����� ����� �������
    [SerializeField] private Transform _pointToMove;


    private void Update()
    {
        Patrol();
    }

    public void SwapPosition(Transform nextPositionToMove)
    {
        _pointToMove = nextPositionToMove;
    }

    private void Patrol()
    {
        if (_pointToMove == null) return;

        // ����������� � ������� ����� ��������������
        transform.position = Vector3.MoveTowards(transform.position, _pointToMove.position, patrolSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ���� �� � ������� ��������� PlayerStats
        if (collision.TryGetComponent(out IDamageAble player) && collision.gameObject.layer == 6)
        {
            Debug.Log("�����");
            StartCoroutine(Attack(player));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerStats player))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator Attack(IDamageAble player)
    {
        while (true) 
        {
            Debug.Log("�����1");
            player.GetDamage(_damageAmount); // ������� ���� ������
            yield return new WaitForSeconds(attackCooldown);
        }
    }
}


