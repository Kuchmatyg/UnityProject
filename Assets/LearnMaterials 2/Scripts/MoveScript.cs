using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : SampleScript
{
    [Tooltip("Позиция, на которую нужно передвинуться")]
    [SerializeField] 
    private Vector3 targetPosition = new Vector3(3, 0, 0);

    [Tooltip("Скорость передвижения")]
    [SerializeField] private float speed = 1f;
    private Vector3 startPosition;
    private bool isMoving;

    private void Awake()
    {
        startPosition = transform.position;
    }

    public override void Use()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveCoroutine());
        }
    }

    private IEnumerator MoveCoroutine()
    {
        isMoving = true;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;

        while (transform.position != targetPosition)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }

        isMoving = false;
    }
}

