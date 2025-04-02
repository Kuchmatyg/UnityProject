using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkDestroyScript : SampleScript
{
    [SerializeField] private Transform target;
    [SerializeField] private float shrinkTime = 1f;

    public override void Use()
    {
        if (target != null)
        {
            StartCoroutine(ShrinkAndDestroyCoroutine());
        }
    }

    private IEnumerator ShrinkAndDestroyCoroutine()
    {
        List<Coroutine> shrinkCoroutines = new List<Coroutine>();

        foreach (Transform child in target)
        {
            shrinkCoroutines.Add(StartCoroutine(ShrinkObject(child)));
        }

        foreach (var coroutine in shrinkCoroutines)
        {
            yield return coroutine;
        }

        Debug.Log("Все дочерние объекты сжаты и удалены");
    }

    private IEnumerator ShrinkObject(Transform obj)
    {
        Vector3 originalScale = obj.localScale;
        float elapsed = 0f;

        while (elapsed < shrinkTime)
        {
            obj.localScale = Vector3.Lerp(originalScale, Vector3.zero, elapsed / shrinkTime);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(obj.gameObject);
    }
}