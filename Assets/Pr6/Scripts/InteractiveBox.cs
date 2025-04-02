using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    private InteractiveBox next; // Ссылка на следующий объект

    public void AddNext(InteractiveBox box)
    {
        next = box; // Устанавливаем следующий объект
    }

    void Update()
    {
        if (next != null)
        {
            // Рисуем луч для отладки
            Debug.DrawLine(transform.position, next.transform.position, Color.green);
            // Проверяем попадание луча в ObstacleItem
            Vector3 direction = next.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction.normalized, out RaycastHit hit, direction.magnitude))
            {
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                if (obstacle != null)
                {
                    obstacle.GetDamage(Time.deltaTime); // Наносим урон со временем
                }
            }
        }
    }
}
