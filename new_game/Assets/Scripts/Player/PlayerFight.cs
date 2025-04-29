using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Transform _atackPoint;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics2D.OverlapBox(_atackPoint.position, new Vector2(1, 1), 0, _layerMask))
            {
                Collider2D[] enemy = Physics2D.OverlapBoxAll(_atackPoint.position, new Vector2(1, 1), 0, _layerMask);
                foreach (var hitObject in enemy)
                {
                    Debug.Log(hitObject.name);
                    if (hitObject.TryGetComponent(out IDamageAble iDamagable))
                    {
                        iDamagable.GetDamage(_playerStats.PlayerDamage);
                    }
                }
            }
        }
    }
}
