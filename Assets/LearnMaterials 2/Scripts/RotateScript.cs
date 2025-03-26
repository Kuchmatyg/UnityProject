using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : SampleScript
{
    [Tooltip("”гол на который нужно развернутс€")]
    [SerializeField] 
    private Vector3 targetRotation = new Vector3(0, 90, 0);

    [Tooltip("—корость разворота")]
    [SerializeField] private float rotationSpeed = 10f;
    private Quaternion startRotation;
    private bool isRotating;

    private void Awake()
    {
        startRotation = transform.rotation;
    }

    public override void Use()
    {
        if (!isRotating)
        {
            StartCoroutine(RotateCoroutine());
        }
    }

    private IEnumerator RotateCoroutine()
    {
        isRotating = true;
        Quaternion targetQuat = Quaternion.Euler(targetRotation);
        float angle = Quaternion.Angle(startRotation, targetQuat);
        float duration = angle / rotationSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetQuat, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetQuat;
        isRotating = false;
    }
}

