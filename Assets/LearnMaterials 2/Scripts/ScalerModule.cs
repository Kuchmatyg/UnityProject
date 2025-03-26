using System.Collections;
using UnityEngine;

[HelpURL("https://docs.google.com/document/d/1rdTEVSrCcYOjqTJcFCHj46RvnbdJhmQUb3gHMDhVftI/edit?usp=sharing")]
public class ScalerModule : MonoBehaviour
{
    [Header("Scale Settings")]
    [Tooltip("Увеличение объекта до этих параметров. Минимальное значение по каждой оси: 0.1")]
    [SerializeField, Min(0.1f)]
    private Vector3 targetScale = new Vector3(2,2,2);

    [Tooltip("Скорость изменения размеров объекта")]
    [SerializeField, Range(0.1f, 2f)]
    private float changeSpeed;

    private Vector3 defaultScale;
    private Transform myTransform;
    private bool toDefault;

    private void Start()
    {
        myTransform = transform;
        defaultScale = myTransform.localScale;
        toDefault = false;
    }

    [ContextMenu("Уеличить объект")]
    public void ActivateModule()
    {
        OnValidate();
        Vector3 target = toDefault ? defaultScale : targetScale;
        StopAllCoroutines();
        StartCoroutine(ScaleCoroutine(target));
        toDefault = !toDefault;
    }

    [ContextMenu("Уменьшить объект")]
    public void ReturnToDefaultState()
    {
        toDefault = true;
        ActivateModule();
    }

    private IEnumerator ScaleCoroutine(Vector3 target)
    {
        Vector3 start = myTransform.lossyScale;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime * changeSpeed;
            myTransform.localScale = Vector3.Lerp(start, target, t);
            yield return null;
        }
        myTransform.localScale = target;
    }

    private void OnValidate()
    {
        targetScale = new Vector3(
            Mathf.Max(4f, targetScale.x),
            Mathf.Max(4f, targetScale.y),
            Mathf.Max(4f, targetScale.z)
        );
        changeSpeed = Mathf.Clamp(changeSpeed, 0.1f, 2f);
    }
}
