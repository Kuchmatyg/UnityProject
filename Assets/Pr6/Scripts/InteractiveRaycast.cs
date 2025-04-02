using System;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject prefab; // Префаб для создания
    private InteractiveBox selectedBox; // Выбранный InteractiveBox
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левый клик
        {
            HandleLeftClick();
        }
        else if (Input.GetMouseButtonDown(1)) // Правый клик
        {
            HandleRightClick();
        }
    }

    private void HandleLeftClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("InteractivePlane"))
            {
                // Создаем новый InteractiveBox
                Vector3 spawnPosition = hit.point + hit.normal * (prefab.transform.localScale.y * 0.6f);
                if (!Physics.CheckSphere(spawnPosition, prefab.transform.localScale.x * 0.5f))
                {
                    Instantiate(prefab, spawnPosition, Quaternion.identity);
                }
               
            }
            else if (hit.collider.TryGetComponent<InteractiveBox>(out var clickedBox))
            {
                if (selectedBox == null)
                {
                    selectedBox = clickedBox; // Запоминаем первый объект
                }
                else if (selectedBox != clickedBox)
                {
                    selectedBox.AddNext(clickedBox); // Связываем с новым
                    selectedBox = null; // Сбрасываем выбор
                }
                
            }
        }
    }

    private void HandleRightClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            InteractiveBox box = hit.collider.GetComponent<InteractiveBox>();
            if (box != null)
            {
                Destroy(box.gameObject); // Удаляем объект
            }
        }
    }
}
