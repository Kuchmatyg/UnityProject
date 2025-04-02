using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField,Range(0f, 1f)]
    private float currentValue = 1f; // Здоровье препятствия

    [SerializeField]
    private UnityEvent onDestroyObstacle; // Событие при уничтожении

    private Renderer renderer; // Для изменения цвета

    void Start()
    {
        renderer = GetComponent<Renderer>();
        UpdateColor(); // Устанавливаем начальный цвет
    }

    public void GetDamage(float value)
    {
        currentValue = Mathf.Clamp01(currentValue - value); // Уменьшаем здоровье
        UpdateColor(); // Обновляем цвет

        if (currentValue <= 0f)
        {
            onDestroyObstacle?.Invoke(); // Вызываем событие
            Destroy(gameObject); // Удаляем объект
        }
    }

    private void UpdateColor()
    {
        if (renderer != null)
        {
            // Плавный переход от белого к красному
            renderer.material.color = Color.Lerp(Color.red, Color.white, currentValue);
        }
    }
}
