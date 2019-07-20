using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNG_movement : MonoBehaviour
{
    private float movementDuration = 2.0f;
    private float waitBeforeMoving = 0.000001f;
    private bool hasArrived = false;

    private void Update()
    {
        if (!hasArrived)
        {
            hasArrived = true;
            float randX = Random.Range(-50f,50f);
            float randZ = Random.Range(-50f, 50f);
            StartCoroutine(MoveToPoint(new Vector3(randX, 5, randZ)));
        }
    }

    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }

        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;
    }
}