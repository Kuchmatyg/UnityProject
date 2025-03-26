using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1RMamVxE-yUpSfsPD_dEa4-Ak1qu6NTo83qY1O4XLxUY/edit?usp=sharing")]
public class DestroyModule : MonoBehaviour
{
    [Tooltip("Задержка между удалениями отдельных частей")]
    [SerializeField, Min(0.01f)]   
    private float destroyDelay;

    [Tooltip("Минимальное количество дочерних объектов, которое должно остаться после удаления")]
    [SerializeField, Min(0)]
    private int minimalDestroyingObjectsCount;

    private Transform myTransform;

    private void Awake()
    {
        myTransform = transform;
        OnValidate();
    }

    [ContextMenu("Начать удаление объектов")]
    public void ActivateModule()
    {
        if (myTransform.childCount <= minimalDestroyingObjectsCount)
        {
            Debug.LogWarning("Недостаточно дочерних объектов для активации модуля!");
            return;
        }
        StartCoroutine(DestroyRandomChildObjectCoroutine());
    }

    private IEnumerator DestroyRandomChildObjectCoroutine()
    {
        while (myTransform.childCount > minimalDestroyingObjectsCount)
        {
            int index = Random.Range(0, myTransform.childCount - 1);
            Destroy(myTransform.GetChild(index).gameObject);
            yield return new WaitForSeconds(destroyDelay);
        }
        Destroy(gameObject, Time.deltaTime);
    }
    private void OnValidate()
    {
        if (destroyDelay > 5f) destroyDelay = 5f;
        if (minimalDestroyingObjectsCount > 216) minimalDestroyingObjectsCount = 216;
    }
}
