using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // ������ �� ������

    void Update()
    {
        // ���������, ���� �� ������ �� ������
        if (player != null)
        {
            // ���������� ������� ������ � ������� �� ��� X
            if (player.position.x > transform.position.x)
            {
                // ����� ������, ������������ ������� ������
                transform.localScale = new Vector3(1, 1, 1); // ������� ������
            }
            else
            {
                // ����� �����, ������������ ������� �����
                transform.localScale = new Vector3(-1, 1, 1); // ������� �����
            }
        }
    }
}
