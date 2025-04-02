using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField,Range(0f, 1f)]
    private float currentValue = 1f; // �������� �����������

    [SerializeField]
    private UnityEvent onDestroyObstacle; // ������� ��� �����������

    private Renderer renderer; // ��� ��������� �����

    void Start()
    {
        renderer = GetComponent<Renderer>();
        UpdateColor(); // ������������� ��������� ����
    }

    public void GetDamage(float value)
    {
        currentValue = Mathf.Clamp01(currentValue - value); // ��������� ��������
        UpdateColor(); // ��������� ����

        if (currentValue <= 0f)
        {
            onDestroyObstacle?.Invoke(); // �������� �������
            Destroy(gameObject); // ������� ������
        }
    }

    private void UpdateColor()
    {
        if (renderer != null)
        {
            // ������� ������� �� ������ � ��������
            renderer.material.color = Color.Lerp(Color.red, Color.white, currentValue);
        }
    }
}
