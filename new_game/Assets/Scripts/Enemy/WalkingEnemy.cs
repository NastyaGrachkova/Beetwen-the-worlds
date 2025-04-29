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

using UnityEngine;

public class PatrollingEnemy : EnemyStats
{
    public float patrolSpeed = 2f; // �������� ��������������
    public Transform[] patrolPoints; // ����� ��������������
    private int currentPatrolIndex; // ������ ������� ����� ��������������

    [SerializeField] private int _damageAmount = 10; // ���������� �����, ���������� ������
    public float attackRange = 1.5f; // ���������, �� ������� ���� ����� ��������� ������
    public float attackCooldown = 1f; // ����� ����� �������
    private float lastAttackTime; // ����� ��������� �����

    private void Start()
    {
        currentPatrolIndex = 0; // �������� � ������ ����� ��������������
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        // ����������� � ������� ����� ��������������
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        // ���������, �������� �� �� �����
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // ��������� � ��������� �����
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���������, ���� �� � ������� ��������� PlayerStats
        if (collision.TryGetComponent(out PlayerStats player))
        {
            Attack(player);
        }
    }

    private void Attack(PlayerStats player)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            player.GetDamage(_damageAmount); // ������� ���� ������
            lastAttackTime = Time.time; // ��������� ����� ��������� �����
            Debug.Log("���� �������� ������. ����: " + _damageAmount);
        }
    }
}


