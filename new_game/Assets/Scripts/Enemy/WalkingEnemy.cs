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
//        Debug.Log("Объект вошел в триггер: " + collision.name);
//        // Проверяем, есть ли у объекта компонент PlayerStats
//        if (collision.TryGetComponent(out PlayerStats player))
//        {
//            // Наносим урон игроку
//            player.GetDamage(_damageAmount);
//        }
//    }
//}

using UnityEngine;

public class PatrollingEnemy : EnemyStats
{
    public float patrolSpeed = 2f; // Скорость патрулирования
    public Transform[] patrolPoints; // Точки патрулирования
    private int currentPatrolIndex; // Индекс текущей точки патрулирования

    [SerializeField] private int _damageAmount = 10; // Количество урона, наносимого игроку
    public float attackRange = 1.5f; // Дистанция, на которой враг может атаковать игрока
    public float attackCooldown = 1f; // Время между атаками
    private float lastAttackTime; // Время последней атаки

    private void Start()
    {
        currentPatrolIndex = 0; // Начинаем с первой точки патрулирования
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        // Перемещение к текущей точке патрулирования
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        // Проверяем, достигли ли мы точки
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Переходим к следующей точке
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем, есть ли у объекта компонент PlayerStats
        if (collision.TryGetComponent(out PlayerStats player))
        {
            Attack(player);
        }
    }

    private void Attack(PlayerStats player)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            player.GetDamage(_damageAmount); // Наносим урон игроку
            lastAttackTime = Time.time; // Обновляем время последней атаки
            Debug.Log("Враг атаковал игрока. Урон: " + _damageAmount);
        }
    }
}


