using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    private InteractiveBox next; // ������ �� ��������� ������

    public void AddNext(InteractiveBox box)
    {
        next = box; // ������������� ��������� ������
    }

    void Update()
    {
        if (next != null)
        {
            // ������ ��� ��� �������
            Debug.DrawLine(transform.position, next.transform.position, Color.green);
            // ��������� ��������� ���� � ObstacleItem
            Vector3 direction = next.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, direction.magnitude))
            {
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                if (obstacle != null)
                {
                    obstacle.GetDamage(Time.deltaTime); // ������� ���� �� ��������
                }
            }
        }
    }
}
