using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCloneJutsu : SampleScript
{
    [SerializeField] private GameObject prefab; // Префаб, который будет клонироваться
    [SerializeField] private int count = 5; // Количество копий
    [SerializeField] private float step = 2f; // Шаг между объектами

    public override void Use()
    {
        if (prefab == null)
        {
            Debug.LogWarning("Префаб не задан!");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            Vector3 position = transform.position + transform.forward * step * i;
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

}
