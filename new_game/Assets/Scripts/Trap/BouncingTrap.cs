using System.Collections;
using UnityEngine;

public class BouncingTrap : Trap
{
    [SerializeField] private float bounceForce = 10f; // ����, � ������� ����� ������������� �����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ActivateTrap(collision.collider)); 
    }

    protected override IEnumerator ActivateTrap(Collider2D collision)
    {
        if (collision.TryGetComponent(out Rigidbody2D playerRigidbody) && !IsTrapActivated)
        {
            IsTrapActivated = true; // ������ �� ��������� ������������ �������
            playerRigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse); // ��������� ���� �����
            yield return new WaitForSeconds(0.5f); // �������� ����� ��������� �������������
            IsTrapActivated = false; 
        }
        yield return null;
    }
}

